using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class AwakeRoom_Door : MonoBehaviour {

	public SFS2X_Connect network;

	void Start()
	{
		network = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}
	void Update () 
	{
		if (network.awakeroomdoor == true) {
			CameraShaker.Instance.ShakeOnce (4f, 10f, 0.1f, 6f);
			GetComponent<Animator> ().Play ("Door_Open");
			network.awakeroomdoor = false;
		}
	}
}
