using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPuzzle : MonoBehaviour {
	public bool destroy_puzzle;
	void Update () 
	{
		if(destroy_puzzle == true)
		{
			Destroy(this.gameObject);
		}
	}
}
