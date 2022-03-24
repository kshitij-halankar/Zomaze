using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
	public string ActivateTag = "Player";

	public bool MakeToggle = true;

	private bool localToggle = false;

	public event System.Action<Collider> OnDoorEnterTrigger;
	public event System.Action<Collider> OnDoorExitTrigger; 
	public event System.Action<bool> ToggleUpdate;

	private void Update()
	{
		if(MakeToggle)
			{
				ToggleUpdate(localToggle);
			}
	}  

	private void OnTriggerEnter(Collider other)	
	{
		if (other.tag == ActivateTag)
		{
		if (MakeToggle)
			{
				localToggle = true;
			}
		else
			{
				OnDoorEnterTrigger(other);
			}
		}
	}
	private void OnTriggerExit(Collider other)	
	{
		if (other.tag == ActivateTag)
		{
		if (MakeToggle)
			{
		OnDoorExitTrigger(other);
			}
		}
	}
}
