using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
	private string ActivateTag = "Player";

	private bool MakeToggle = true;

	private bool localToggle = false;

	public event System.Action<Collider> OnDoorEnterTrigger;
	public event System.Action<Collider> OnDoorExitTrigger; 
	public event System.Action<bool> ToggleUpdate;

	private void Update()
	{
	
	}  

	private void OnTriggerEnter(Collider other)	
	{

		if (other.tag == ActivateTag)
		{
			OnDoorEnterTrigger(other);
		}
	}
}
