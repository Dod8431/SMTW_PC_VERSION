using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Dall : MonoBehaviour {

	public GameObject pz1controller;
	public List<BoxCollider> colliderList;

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
		if (pz1controller.GetComponent<PZ1Controller> ().pz1entrancevalidate == true) {	
			GetComponent<Animator> ().Play ("Dall_on");
			if (gameObject.name == "Ground_Dall_1") {
				pz1controller.GetComponent<PZ1Controller> ().code += "1";
			}

			if (gameObject.name == "Ground_Dall_2") {
				pz1controller.GetComponent<PZ1Controller> ().code += "2";
			}

			if (gameObject.name == "Ground_Dall_3") {
				pz1controller.GetComponent<PZ1Controller> ().code += "3";
			}

			if (gameObject.name == "Ground_Dall_4") {
				pz1controller.GetComponent<PZ1Controller> ().code += "4";
			}
		}
	}

	void Reboot()
	{
		GetComponent<Animator> ().Play ("Dall_off");
	}
}
