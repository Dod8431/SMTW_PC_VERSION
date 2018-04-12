using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Activation : MonoBehaviour {

	public SFS2X_Connect sfs;
	public GameObject player;
	public GameObject roof;
	public GameObject veapillar;
	public GameObject pedestral;
	public GameObject veaplayer;
	public GameObject particles;
	public Animator audiomain;
	private bool check = false;
	private bool check2 = false;

	void Start()
	{
		player = GameObject.Find ("Player");
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
		audiomain = GameObject.Find("Audio_Manager").GetComponent<Animator>();
	}

	void OnTriggerStay(Collider other)
	{
		if (check == false && check2 == false) {
			particles.GetComponent<Animator> ().Play ("ParticleActivate");
			check = true;
		}

		if(Input.GetKey(KeyCode.E) && check2 == false)
		{
			audiomain.Play("Puzzle_Music_On");
			other.GetComponent<TriggersPlayer> ().activate = true;
			sfs.BroadcastMessage ("P2Entrance");
			pedestral.GetComponent<Animator> ().Play ("Activate");
			roof.GetComponent<Animator> ().Play ("Timer_Roof");
			veapillar.SetActive (true);
			veaplayer.SetActive (false);
			particles.SetActive (false);
			check2 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		check = false;
		particles.GetComponent<Animator> ().Play ("ParticleDesactivate");
	}
}
