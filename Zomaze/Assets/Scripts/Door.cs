using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public DoorEvent doorEvent;

    private Quaternion StartingRotation;
    private Vector3 RotateTo;
    // Start is called before the first frame update
    void Start()
    {
        doorEvent.OnDoorEnterTrigger += DoorEvent_OnDoorEnterTrigger;
        doorEvent.OnDoorExitTrigger += DoorEvent_OnDoorExitTrigger;
        doorEvent.ToggleUpdate += DoorEvent_ToggleUpdate;

        StartingRotation = gameObject.transform.rotation;
        RotateTo = new Vector3(0, 270, 0);
        //	gameObject.transform.rotation = Quaternion.Euler(RotateTo);
    }

    private void DoorEvent_ToggleUpdate(bool obj)
    {
        if (obj)
        {
            gameObject.transform.rotation = Quaternion.Euler(RotateTo);
        }
        else
        {
            gameObject.transform.rotation = StartingRotation;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void DoorEvent_OnDoorEnterTrigger(Collider obj)
    {
        gameObject.transform.rotation = Quaternion.Euler(RotateTo);
    }

    private void DoorEvent_OnDoorExitTrigger(Collider obj)
    {
        gameObject.transform.rotation = StartingRotation;
    }

}
