using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRoom_Door : MonoBehaviour {

	public SFS2X_Connect network;

	void Start()
	{
		network = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}
	void Update () 
	{
		if (network.awakeroomdoor == true) {
			Debug.Log ("cc");
			GetComponent<Animator> ().Play ("Door_Open");
			network.awakeroomdoor = false;
		}
	}
}
