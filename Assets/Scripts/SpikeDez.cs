using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDez : MonoBehaviour 
{
	public GameObject spiketrap;
	public GameObject outline;
	public GameObject indicator;
	public bool desactivated;
	public bool outlined;

	void Update()
	{
		if(outlined == true)
		{
			outline.SetActive(true);
		}
		else{
			outline.SetActive(false);
		}

		if(desactivated == true)
		{
			Destroy(indicator);
			spiketrap.GetComponent<BoxCollider>().enabled = false;
			spiketrap.GetComponentInChildren<TrapSpike>().sound.clip = spiketrap.GetComponentInChildren<TrapSpike>().spikedez;
			spiketrap.GetComponentInChildren<TrapSpike>().sound.Play(0);
			Destroy(this.gameObject);
		}
		outlined = false;
	}

}
