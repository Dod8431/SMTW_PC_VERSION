using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {

	public string code;

	public SFS2X_Connect sfs;

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	public GameObject woodpillar1;
	public GameObject woodpillar2;
	public GameObject woodpillar3;
	public GameObject woodpillar4;

	public GameObject vealaby;

	private bool validate;

	void Start () {
		sfs = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}

	void Update () 
	{
		if (code == "3412" && validate == false) {
			StartCoroutine (Validate ());
		}

		if (code.Length == 4 && code != "3412") {
			code = "";
			StartCoroutine (Error ());
		}
	}

	IEnumerator Validate()
	{
		yield return new WaitForSeconds (0.25f);
		woodpillar1.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar2.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar3.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar4.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		vealaby.SetActive(true);
		yield return new WaitForSeconds (2);
		sfs.BroadcastMessage ("MainScene");
		yield return new WaitForSeconds (10);
		sfs.P2MiniGame ();
		validate = true;

	}

	IEnumerator Error()
	{
		woodpillar1.GetComponent<Animator> ().Play ("WoodPillarError");
		yield return new WaitForSeconds (0.125f);
		woodpillar2.GetComponent<Animator> ().Play ("WoodPillarError");
		yield return new WaitForSeconds (0.125f);
		woodpillar3.GetComponent<Animator> ().Play ("WoodPillarError");
		yield return new WaitForSeconds (0.125f);
		woodpillar4.GetComponent<Animator> ().Play ("WoodPillarError");
		yield return new WaitForSeconds (0.125f);
		button1.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
		yield return new WaitForSeconds (0.125f);
		button2.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
		yield return new WaitForSeconds (0.125f);
		button3.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
		yield return new WaitForSeconds (0.125f);
		button4.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");

	}
}
