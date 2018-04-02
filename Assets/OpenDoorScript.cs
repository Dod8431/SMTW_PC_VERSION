using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour {

	public GameObject door;
	
	void OnTriggerStay()
	{
		if (Input.GetKey (KeyCode.E)) {
			door.GetComponent<Animator> ().Play ("Door_Open");
		}
	}	
}
