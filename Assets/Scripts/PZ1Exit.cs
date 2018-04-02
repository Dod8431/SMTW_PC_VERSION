using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Exit : MonoBehaviour {

	public SFS2X_Connect sfs;

	public GameObject veapillar;
	public GameObject veaplayer;

	void Start()
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			sfs.BroadcastMessage ("MainScene");
			veapillar.SetActive (false);
			veaplayer.SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
