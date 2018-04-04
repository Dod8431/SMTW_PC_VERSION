using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {

	public string code;

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	public GameObject woodpillar1;
	public GameObject woodpillar2;
	public GameObject woodpillar3;
	public GameObject woodpillar4;

	void Start () {
		
	}

	void Update () 
	{
		if (code == "3412") {
			StartCoroutine (Validate ());
		}

		if (code.Length == 4 && code != "3412") {
			code = "";
			StartCoroutine (Error ());
			button1.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
			button2.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
			button3.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
			button4.GetComponent<Puzzle2_Button> ().BroadcastMessage ("Reboot");
		}
	}

	IEnumerator Validate()
	{
		woodpillar1.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar2.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar3.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);
		woodpillar4.GetComponent<Animator> ().Play ("WoodPillarValidate");
		yield return new WaitForSeconds (0.25f);

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

	}
}
