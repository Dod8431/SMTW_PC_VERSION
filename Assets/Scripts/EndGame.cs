using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public GameObject endgame;
	public GameObject endcamera;
	public GameObject player;

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
		endgame.GetComponent<Animator>().Play("END_GAME");
		player.SetActive(false);
		endcamera.SetActive(true);
		StartCoroutine(WaitAndEnd());
		}

	}

	IEnumerator WaitAndEnd()
	{
		yield return new WaitForSeconds(8);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menus Principal");
	}
}
