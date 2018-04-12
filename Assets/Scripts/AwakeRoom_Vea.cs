using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRoom_Vea : MonoBehaviour {

	public GameObject veaplayer;
	public GameObject veapillar;
	public GameObject pedestral;
	public GameObject particles;
	private bool check;
	private bool check2;

	public GameObject infotext;
	public SFS2X_Connect sfs;

	void Start()
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (check == false && check2 == false) {
			particles.GetComponent<Animator> ().Play ("ParticleActivate");
			infotext.SetActive (true);
			check = true;
		}

		if (other.tag == "Player" && check2 == false) {
			if (Input.GetKeyDown (KeyCode.E)) {
				infotext.GetComponent<TextMesh> ().text = "";
				pedestral.GetComponent<Animator> ().Play ("Activate");
				sfs.BroadcastMessage ("AwakeRoomVeaNear");
				StartCoroutine (VeaExplode ());
				veapillar.SetActive (true);
				veaplayer.SetActive (false);
				particles.SetActive (false);
				check2 = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			infotext.SetActive (false);
			check = false;
			particles.GetComponent<Animator> ().Play ("ParticleDesactivate");
		}
	}

	IEnumerator VeaExplode()
	{
		veapillar.GetComponent<Animator> ().Play ("VeaExplode");
		yield return new WaitForSeconds (3.1f);
		veaplayer.SetActive (true);
		veapillar.SetActive (false);
	}
}
