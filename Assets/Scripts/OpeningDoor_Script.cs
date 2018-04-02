using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor_Script : MonoBehaviour {

	private Animator anim;
	private BoxCollider collider;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		collider = GetComponent<BoxCollider> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKey (KeyCode.E)) {
			anim.Play ("Open_Door");
			collider.enabled = false;
		}
	}
}
