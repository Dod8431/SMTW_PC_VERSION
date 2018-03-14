using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpike : MonoBehaviour {

private Animator anim;
private Animator camanim;
private Animator screen;
public AudioSource sound;
public Transform respawn;
public GameObject playercam;
public GameObject screenfade;
public GameObject gamesound;
public GameObject player;
public AudioClip spikeout;
public AudioClip spikedez;

	void Start()
	{
		anim = GetComponent<Animator>();
		camanim = player.GetComponent<Animator>();
		screen = screenfade.GetComponent<Animator>();
		sound = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			gamesound.GetComponent<Animator>().Play("SOUND_FADE_OUT");
			sound.clip = spikeout;
			sound.Play(0);
			anim.Play("activate_spikes");
			camanim.enabled = true;
			camanim.SetBool("Dead", true);
			screen.Play("SCREEN_FADE_DIE");
			StartCoroutine(WaitAndRespawn());

		}
			
	}
	IEnumerator WaitAndRespawn()
	{
		yield return new WaitForSeconds(6);
		camanim.SetBool("Dead", false);
		camanim.enabled = false;
		player.transform.position = respawn.position;
		player.transform.rotation = respawn.rotation;
		yield return new WaitForSeconds(2);
		screen.Play("SCREEN_FADE_IN");
		gamesound.GetComponent<Animator>().Play("SOUND_FADE_IN");
	}
}
