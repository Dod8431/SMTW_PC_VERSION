using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Activation : MonoBehaviour {

	public SFS2X_Connect sfs;
	public GameObject player;
	public GameObject roof;
	public GameObject veapillar;
	public GameObject pedestral;
	public GameObject veaplayer;
	public GameObject particles;
	public GameObject doorentrance;
	public GameObject pillarsandsymbols;
	public Transform deadrespawn;
	private bool check = false;
	private bool check2 = false;

	void Start()
	{
		player = GameObject.Find ("Player");
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (check == false && check2 == false) {
			particles.GetComponent<Animator> ().Play ("ParticleActivate");
			check = true;
		}

		if(Input.GetKey(KeyCode.E) && check2 == false)
		{
			other.GetComponent<TriggersPlayer> ().activate = true;
			sfs.BroadcastMessage ("P1Entrance");
			pedestral.GetComponent<Animator> ().Play ("Activate");
			roof.GetComponent<Animator> ().Play ("RoofClose");
			veapillar.SetActive (true);
			veaplayer.SetActive (false);
			particles.SetActive (false);
			doorentrance.GetComponent<Animator> ().Play ("Door_Close");
			pillarsandsymbols.GetComponent<Animator> ().Play ("TimerPuzzle1");
			check2 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		check = false;
		particles.GetComponent<Animator> ().Play ("ParticleDesactivate");
	}

	void Update()
	{
		/*if (check2 == true) {
			StartCoroutine (Timer ());
		} else {
			StopAllCoroutines ();
		}*/
	}

	/*IEnumerator Timer()
	{
		Debug.Log ("cc");
		yield return new WaitForSeconds (120);
		player.GetComponent<TriggersPlayer> ().BroadcastMessage ("Wait", deadrespawn);
		pedestral.GetComponent<Animator> ().Play ("Idle");
		pillarsandsymbols.GetComponent<Animator> ().Play ("Wait");
		veapillar.SetActive (false);
		veaplayer.SetActive (true);
		player.GetComponent<TriggersPlayer> ().activate = false;
		check2 = false;
	}*/
}
