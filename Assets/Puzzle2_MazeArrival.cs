using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Puzzle2_MazeArrival : MonoBehaviour {
	public SFS2X_Connect sfs;
	public bool p2mazevalidate;
	private bool check;

	void Start()
	{
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void Update()
	{
		//p2mazevalidate = sfs.mazevalidate;
		if(sfs.mazevalidate == true && check == false)
		{
			StartCoroutine(Maze_End());
			check = true;
		}
		
	}

	IEnumerator Maze_End()
	{
		GameObject.Find("Scaler").transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
		this.transform.GetChild(0).gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		CameraShaker.Instance.ShakeOnce (1.5f,4f,6f,18f);
		GetComponentInParent<Animator>().Play("MazeEnd");
		yield return new WaitForSeconds(10f);
		CameraShaker.Instance.ShakeOnce (3f,5f,0.1f,2f);
		yield return new WaitForSeconds(5.5f);
		CameraShaker.Instance.ShakeOnce (1.5f,3f,1f,4f);
	}
}
