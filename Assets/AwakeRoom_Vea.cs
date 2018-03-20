using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRoom_Vea : MonoBehaviour {

	public GameObject vea;
	public GameObject veaplayer;

	public Material lambert;
	public GameObject infotext;
	public SFS2X_Connect network;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			infotext.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				network.BroadcastMessage ("AwakeRoomVeaNear");
				infotext.GetComponent<TextMesh> ().text = "";
				StartCoroutine (VeaExplode ());
				GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			infotext.SetActive (false);
		}
	}

	IEnumerator VeaExplode()
	{
		vea.GetComponent<Animator> ().Play ("VeaExplode");
		yield return new WaitForSeconds (3.1f);
		veaplayer.SetActive (true);
		vea.SetActive (false);
	}
}
