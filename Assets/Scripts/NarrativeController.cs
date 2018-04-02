using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

	public SFS2X_Connect sfs;
	public string narrative_content;

	public GameObject vea;
	public GameObject player;
	public GameObject narrative_waypoint;

	private bool check = false;

	void Start () 
	{
		player = GameObject.Find ("Player");
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && check == false) {
			vea.GetComponent<VeaFollow>().wayPoint = narrative_waypoint;
			vea.GetComponent<Animator> ().enabled = false;
			Debug.Log (narrative_content);
			//sfs.Narrative (narrative_content);
			check = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			vea.GetComponent<Animator> ().enabled = true;
			vea.GetComponent<VeaFollow>().wayPoint = player;
		}
	}
}
