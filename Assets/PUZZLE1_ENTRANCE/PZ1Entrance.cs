using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ1Entrance : MonoBehaviour {

	public GameObject veapillar;
	public GameObject veaplayer;
	public GameObject particles;
	private bool check = false;
	private bool check2 = false;

	void OnTriggerStay(Collider other)
	{
		if (check == false && check2 == false) {
			particles.SetActive (true);
			check = true;
		}

		if(Input.GetKey(KeyCode.E))
		{
			veapillar.SetActive (true);
			veaplayer.SetActive (false);
			check2 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		check = false;
		particles.SetActive (false);
	}
		
}

	
