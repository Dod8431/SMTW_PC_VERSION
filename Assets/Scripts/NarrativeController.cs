using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class NarrativeController : MonoBehaviour {

	public SFS2X_Connect sfs;
	public int narrative_index;

	public GameObject vea;
	public GameObject player;
	public GameObject narrative_waypoint;

	public GameObject door;

	private bool check = false;

	void Start () 
	{
		player = GameObject.Find ("Player");
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void Update()
	{
		if (sfs.narrativeroom1 == true) {
			StartCoroutine (WaitAndOpen ());
			sfs.narrativeroom1 = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && check == false) {
			vea.GetComponent<VeaFollow>().wayPoint = narrative_waypoint;
			vea.GetComponent<Animator> ().enabled = false;
			sfs.Narrative (narrative_index);
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

	IEnumerator WaitAndOpen()
	{
		Debug.Log ("cc");
		yield return new WaitForSeconds (1);
		CameraShaker.Instance.ShakeOnce (1.15f, 3f, 0.1f, 5f);
		door.GetComponent<Animator> ().Play ("Open_Door");
		StopAllCoroutines ();
	}
}
