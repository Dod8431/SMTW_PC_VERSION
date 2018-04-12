using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets;
public class JapanExpo_Exit : MonoBehaviour {

	public Animator japanend;
	public Animator audiomanager;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			japanend.Play("JapanEndAnim");
			audiomanager.Play("Sound_Off");
			StartCoroutine(End());
		}
	}

	IEnumerator End()
	{
		yield return new WaitForSeconds(0.75f);
		GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Player_NotMove");
		yield return new WaitForSeconds(4.5f);
		SceneManager.LoadScene(1);
	}
}
