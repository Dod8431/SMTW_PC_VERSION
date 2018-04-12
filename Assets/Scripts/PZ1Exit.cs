using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Exit : MonoBehaviour {

	public SFS2X_Connect sfs;

	public GameObject veapillar;
	public GameObject veaplayer;
		public Animator audiomain;

	void Start()
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
		audiomain = GameObject.Find("Audio_Manager").GetComponent<Animator>();
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			audiomain.Play("Puzzle_Music_Off");
			sfs.BroadcastMessage ("MainScene");
			veapillar.SetActive (false);
			veaplayer.SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
