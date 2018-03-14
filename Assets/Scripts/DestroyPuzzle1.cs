using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPuzzle1 : MonoBehaviour {

public GameObject puzzletodestroy;
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Destroy(puzzletodestroy);
		}
	}
}
