using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Dall : MonoBehaviour {

	public GameObject pz1controller;
	private bool pressed;

	void Start()
	{
		pz1controller = GameObject.Find ("PZ1Controller");
	}

	void Update()
	{
		if (pz1controller.GetComponent<PZ1Controller> ().pz1entrancevalidate == true) {
			
			this.transform.GetChild (0).transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (pz1controller.GetComponent<PZ1Controller> ().checkvalidate == true && pressed == false) {	
			GetComponent<Animator> ().Play ("Dall_on");
			if (gameObject.name == "Ground_Dall_1") {
				pz1controller.GetComponent<PZ1Controller> ().code += "1";
				pressed = true;
			}

			if (gameObject.name == "Ground_Dall_2") {
				pz1controller.GetComponent<PZ1Controller> ().code += "2";
				pressed = true;
			}

			if (gameObject.name == "Ground_Dall_3") {
				pz1controller.GetComponent<PZ1Controller> ().code += "3";
				pressed = true;
			}

			if (gameObject.name == "Ground_Dall_4") {
				pz1controller.GetComponent<PZ1Controller> ().code += "4";
				pressed = true;
			}
		}
	}

	void Reboot()
	{
		StartCoroutine (WaitAndReboot ());
	}

	IEnumerator WaitAndReboot()
	{
		yield return new WaitForSeconds (1);
		GetComponent<Animator> ().Play ("Dall_error");
		pressed = false;
	}
}
