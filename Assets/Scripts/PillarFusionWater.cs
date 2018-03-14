using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarFusionWater : MonoBehaviour {
	public GameObject IcePil;
	public GameObject PlantPil;
	public GameObject SteamPil;
	public GameObject pillarfusion;

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("AirPil"))
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
			Instantiate(IcePil,((this.transform.position + other.transform.position)/2),this.transform.rotation,GameObject.Find("Pillars").transform);
		}

		if(other.CompareTag("EarthPil"))
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
			Instantiate(PlantPil,((this.transform.position + other.transform.position)/2),this.transform.rotation,GameObject.Find("Pillars").transform);
		}

		if(other.CompareTag("FirePil"))
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
			Instantiate(SteamPil,((this.transform.position + other.transform.position)/2),this.transform.rotation,GameObject.Find("Pillars").transform);
		}
	}
}
