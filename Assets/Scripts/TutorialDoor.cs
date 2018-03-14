using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour {

private Animator anim;
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	void OnTriggerStay(Collider other)
	{
		if(Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button2))
		{
			anim.Play("ENTRANCE_OPEN");
			GetComponent<AudioSource>().Play();
		}
	}
}
