using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeaLabyrinthe_Controller : MonoBehaviour {

	public SFS2X_Connect sfs;
	public Transform vea;

	void Start () 
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect>();
	}

	void Update () 
	{
		vea.localPosition = new Vector3 (-0.5f, sfs.veaposz, -sfs.veaposx);
	}
}
