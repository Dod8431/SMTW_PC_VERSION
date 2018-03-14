using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour {
	void OnTriggerExit(Collider player)
	{
		if(player.CompareTag("Player"))
		{
			GameObject.Find("ScreenFade").GetComponent<Animator>().Play("SCREEN_ROOM_CHANGE");
			GameObject.Find("PUZZLE_1_DOOR").GetComponent<AudioSource>().Play();
			GameObject.Find("PUZZLE_1_DOOR").GetComponent<Animator>().Play("CLOSE_DOOR");
			Destroy(GameObject.Find("Line1"));
			Destroy(GameObject.Find("Line2"));
			Destroy(GameObject.Find("Line3"));
			Destroy(GameObject.Find("Line4"));
			Destroy(GameObject.Find("Line5"));
			Destroy(GameObject.Find("Symbols_Lines_Position"));
			RenderSettings.fog = true;
		}
	}
}
