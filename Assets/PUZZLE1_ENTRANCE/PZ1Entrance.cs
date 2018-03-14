using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Entrance : MonoBehaviour {

	public GameObject veatracker;
	public GameObject veapos;
	public GameObject veawaypoint;

	void OnTriggerEnter(Collider other)
	{
		veatracker.GetComponent<VeaFollow> ().anim.Play ("VEA_CENTER");
		veatracker.GetComponent<VeaFollow> ().wayPoint = veawaypoint;
		GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ().BroadcastMessage ("P1Entrance");
		Destroy (this);
	}
}
