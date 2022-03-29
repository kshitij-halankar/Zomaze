using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  //Movement
  [SerializeField] private float speed = 10.0f;
  private float rootSpeed = 90f;
  private Vector3 moveDirection = Vector3.zero;
  private float distance = 0;
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

    if (Input.acceleration.z > 0.05)
    {
      speed = 5.0f;
    }
    else if (Input.acceleration.z < -0.3)
    {
      speed = 5.0f;
    }
    if (Input.acceleration.z > 0.05 || Input.acceleration.z < -0.3)
    {
      Vector3 move = new Vector3(0, 0, -Input.acceleration.z * speed * Time.deltaTime);

      Vector3 movement = transform.TransformDirection(move);
      // Move object


      distance += speed * Time.deltaTime;

      if (distance > 4)
      {
        GetComponent<AudioSource>().Play();
        distance = 0;
      }
      controller.Move(movement);

    }
  }

  public void SetEnabled(bool value)
  {
    enabled = true;
    StartCoroutine(CalibrateYAngle());
  }
}