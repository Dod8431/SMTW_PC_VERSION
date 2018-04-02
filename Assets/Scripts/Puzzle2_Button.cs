using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Button : MonoBehaviour {

	public GameObject pz2controller;

	public GameObject explosion;
	public GameObject button;
	public GameObject outlinemesh;

	public string buttonvalue;
	private bool destroyed;
	public bool pressed;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && destroyed == true && pressed == false) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("Bouton appuyé");
				button.GetComponent<Animator> ().Play ("Button_On");
				pz2controller.GetComponent<Puzzle2_Controller> ().code += buttonvalue;
				pressed = true;
			}
		}

		if (other.tag == "Player" && destroyed == false) {
			outlinemesh.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				explosion.GetComponent<ExplosionSource> ().enabled = true;
				destroyed = true;
			}
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && pressed == false) {
			outlinemesh.SetActive (false);
		}
	}

	void Reboot()
	{
		button.GetComponent<Animator> ().Play ("Idle");
		pressed = false;
	}
}
