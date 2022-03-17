using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float xMaxDistance;
    [SerializeField] private float currentRotation;
    [SerializeField] private float zMaxDistance;
    private Vector3 leftPoint, rightPoint;
    private Vector3 currentTarget;
    private int moveDirection = 1;


    // Start is called before the first frame update
    void Start()
    {
        leftPoint = transform.position - new Vector3(xMaxDistance, 0, zMaxDistance);
        rightPoint = transform.position + new Vector3(xMaxDistance, 0, zMaxDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDirection == 1)
        {
            currentTarget = rightPoint;
        } else if(moveDirection == -1)
        {
            currentTarget = leftPoint;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.01)
        {
            moveDirection *= -1;
        }

        if (Vector3.Distance(transform.position, currentTarget) < 0.5)
        {
            transform.Rotate(new Vector3(0, currentRotation, 0) * Time.deltaTime * 2);
        }
    }

}
