using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarFusionEarth : MonoBehaviour {
public GameObject LavaPil;


	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("FirePil"))
		{
			this.gameObject.SetActive(false);
			Destroy(this.gameObject);
			Destroy(other.gameObject);
			Instantiate(LavaPil,((this.transform.position + other.transform.position)/2),this.transform.rotation,GameObject.Find("Pillars").transform);
		}
	}



}
