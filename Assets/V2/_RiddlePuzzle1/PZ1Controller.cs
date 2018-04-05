using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PZ1Controller : MonoBehaviour {

	public string code;
	public bool pz1entrancevalidate;
	private bool validate = false;

	public GameObject veaspotlight;

	public GameObject dall1;
	public GameObject dall2;
	public GameObject dall3;
	public GameObject dall4;

	public GameObject door;
	private bool checkvalidate;

	void Update () 
	{
		if (code == "1234" && validate == false) {
			door.GetComponent<Animator> ().Play ("Door_Open");
			CameraShaker.Instance.ShakeOnce (3f, 7f, 0.1f, 6f);
			validate = true;
		}

		if (code.Length == 4 && code != "1234") {
			code = "";
			dall1.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			dall2.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			dall3.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			dall4.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
		}

		if (pz1entrancevalidate == true && checkvalidate == false) {
			dall1.GetComponent<Animator> ().Play ("CA_Activate");
			dall2.GetComponent<Animator> ().Play ("CA_Activate");
			dall3.GetComponent<Animator> ().Play ("CA_Activate");
			dall4.GetComponent<Animator> ().Play ("CA_Activate");
			checkvalidate = true;
		}
	}
}
