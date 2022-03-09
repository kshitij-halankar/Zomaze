using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] private float speed = 10.0f;
    private float rootSpeed = 90f;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private CharacterController controller;

    //Rotation via Gyrometer.
    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    //settings.
    private float _smoothing = 0.1f;

    private void Update()
    {
        //Movement using Accelerometer
        applyAccelerometerMovement();

        //Rotation Via Gyrometer.
        ApplyGyroRotation();
        ApplyCalibration();

        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
    }

    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        yield return new WaitForSeconds(1);
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle;
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }

    private void applyAccelerometerMovement()
    {

        if(Input.acceleration.z > 0.05)
        {
            speed = 10.0f;
        }
        else if(Input.acceleration.z < -0.3)
        {
            speed = 5.0f;
        }
        if (Input.acceleration.z > 0.05 || Input.acceleration.z < -0.3)
        {
            Vector3 move = new Vector3(0, 0, -Input.acceleration.z * speed * Time.deltaTime);

            Vector3 movement = transform.TransformDirection(move);

            // Move object
            controller.Move(movement);
        }

        // Code not working - Need to change
        /*
        float speed = 10.0f;
        Vector3 dir = Vector3.zero;

            // we assume that device is held parallel to the ground
            // and Home button is in the right hand

            // remap device acceleration axis to game coordinates:
            //  1) XY plane of the device is mapped onto XZ plane
            //  2) rotated 90 degrees around Y axis
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;

            // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

            // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

            // Move object
       transform.Translate(dir * speed);
        */
        }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
}