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
			button1.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			button2.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			button3.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
			button4.GetComponent<PZ1Dall> ().BroadcastMessage ("Reboot");
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
}
