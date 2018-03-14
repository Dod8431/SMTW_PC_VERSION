using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEntrance : MonoBehaviour {

	public GameObject puzzletimer;
	public GameObject gamecontroller;
	public bool entrancecheck = false;
	public GameObject gameaudio;
	public AudioClip puzzle1music;
	void OnTriggerStay()
	{
		if(Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button2))
		{
			gameaudio.GetComponent<AudioSource>().clip = puzzle1music;
			gameaudio.GetComponent<AudioSource>().Play();
			GetComponentInParent<AudioSource>().Play();
			gamecontroller.GetComponent<Objectives>().entrance_puzzle1 = true;
			GetComponentInParent<Animator>().Play("ENTRANCE_OPEN");
			puzzletimer.GetComponent<Timer3DText>().starttimer = true;
			Destroy(gameObject);
		}
	}
}
