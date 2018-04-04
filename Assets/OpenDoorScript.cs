using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class OpenDoorScript : MonoBehaviour {

	public GameObject door;
	
	void OnTriggerEnter()
	{
		door.GetComponent<Animator> ().Play ("Door_Open");
		CameraShaker.Instance.ShakeOnce (3f, 7f, 0.1f, 6f);
	}	
}
