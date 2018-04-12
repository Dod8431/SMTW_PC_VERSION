using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public bool change;
	public int index2;
	private bool check;

	public void LoadLevel(int index)
	{
		SceneManager.LoadScene(index);
	}

	void Update()
	{
		if(change == true && check == false)
		{
			SceneManager.LoadScene(index2);
			check = false;
		}
	}
}
