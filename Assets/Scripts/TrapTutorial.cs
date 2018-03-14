using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTutorial : MonoBehaviour {

public GameObject floor;
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(floor);
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.2f);
		GetComponent<AudioSource>().Play(0);
		yield return new WaitForSeconds(6);
		GetComponent<AudioSource>().Stop();



	}
}
