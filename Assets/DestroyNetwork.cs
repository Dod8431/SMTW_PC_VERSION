using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNetwork : MonoBehaviour {

	void Awake()
	{
		//Destroy(GameObject.Find("Network_Manager"));
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
