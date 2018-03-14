using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoLeave : MonoBehaviour {

public GameObject tutodoor;
public GameObject timerpuzzle;
	void OnTriggerExit()
	{
		tutodoor.GetComponent<Animator>().Play("DOOR_TUTO_CLOSE");
		this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
		this.gameObject.GetComponent<TutoLeave>().enabled = false;
		timerpuzzle.GetComponent<Timer3DText>().starttimer = true;
		
	}
}
	