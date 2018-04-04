using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggCubitron : MonoBehaviour {

	public GameObject cubitron_sphere;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				cubitron_sphere.SetActive (true);
			}
		}
	}
}
