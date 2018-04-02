using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Entrance : MonoBehaviour {

	public SFS2X_Connect sfs;
	public GameObject veapillar;
	public GameObject pedestral;
	public GameObject veaplayer;
	public GameObject particles;
	public GameObject doorentrance;
	private bool check = false;
	private bool check2 = false;

	public List<GameObject> pillars = new List<GameObject>();
	public List<GameObject> moonsymbols;

	void Start()
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (check == false && check2 == false) {
			particles.SetActive (true);
			check = true;
		}

		if(Input.GetKey(KeyCode.E) && check2 == false)
		{
			sfs.BroadcastMessage ("P1RiddleEntrance");
			pedestral.GetComponent<Animator> ().Play ("Activate");
			foreach (GameObject o in pillars) {
				o.GetComponent<Animator> ().Play ("PylonSymbolActivate");
			}
			foreach (GameObject o in moonsymbols) {
				o.GetComponent<Animator> ().Play ("MoonSymbolActivate");
			}
			veapillar.SetActive (true);
			veaplayer.SetActive (false);
			particles.SetActive (false);
			doorentrance.GetComponent<Animator> ().Play ("Close_Door");
			check2 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		check = false;
		particles.SetActive (false);
	}
		
}

	
