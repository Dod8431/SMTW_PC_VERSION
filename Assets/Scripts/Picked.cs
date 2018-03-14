using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picked : MonoBehaviour {
	private Vector3 scaleto;

	void Update () 
	{	
		Vector3 scaleto = this.transform.localScale;
		if(GameObject.Find("Main Camera").GetComponent<Pickup>().picked == true)
		{
		this.transform.position = GameObject.Find("PlayerHand").transform.position;
		}
	}
}
