using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTutorial2 : MonoBehaviour {

public GameObject player;
public GameObject screenfade;
private Animator anim;
private Animator screen;

	void Start()
	{
		anim = player.GetComponent<Animator>();
		screen = screenfade.GetComponent<Animator>();
	}
	void OnTriggerEnter(Collider other)
	{
		GetComponent<AudioSource>().Play(0);
		anim.enabled = true;
		anim.SetBool("Dead", true);
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		screen.Play("SCREEN_FADE_DIE");
		yield return new WaitForSeconds(6);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MAIN_SCENE");
	}
}
