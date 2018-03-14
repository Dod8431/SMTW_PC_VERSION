using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Dalle : MonoBehaviour {

public GameObject doortuto;
public GameObject meshdalle;
private Animator anim;

void Start()
{
	anim = GetComponent<Animator>();
}

	void OnTriggerEnter()
	{
		doortuto.GetComponent<Animator>().Play("DOOR_TUTO_OPEN");
		doortuto.GetComponent<AudioSource>().enabled = true;
		meshdalle.GetComponent<Renderer>().materials[1].color = Color.cyan;
		anim.Play("DALLE_TUTO");
	}
}
