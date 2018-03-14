using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Reset : MonoBehaviour 
{
	public GameObject FirePil;
	public GameObject EarthPil;
	public GameObject WaterPil;
	public GameObject AirPil;

	public Transform FireRez;
	public Transform EarthRez;
	public Transform WaterRez;
	public Transform AirRez;
	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Debug.Log("Press XButton to reset");
			if(Input.GetButton("Use"))
			{
				foreach (Transform child in GameObject.Find("Pillars").transform) 
				{
     				GameObject.Destroy(child.gameObject);
 				}
				Instantiate(FirePil, FireRez.position, FireRez.rotation, GameObject.Find("Pillars").transform);
				Instantiate(EarthPil, EarthRez.position, EarthRez.rotation, GameObject.Find("Pillars").transform);
				Instantiate(WaterPil, WaterRez.position, WaterRez.rotation, GameObject.Find("Pillars").transform);
				Instantiate(AirPil, AirRez.position, AirRez.rotation, GameObject.Find("Pillars").transform);
			}
		}
	}

}
