using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TriggersPlayer : MonoBehaviour 
{
public GameObject game_controller;
private Transform symbol;
public Color symbolcolorpicker;
public int errorcounter = 0;

void Start()
{
	game_controller = GameObject.Find("GAMECONTROLLER");
}
IEnumerator Wait()
{
	yield return new WaitForSeconds(0.2f);
	game_controller.GetComponent<Objectives>().Puzzle_1_Generator();
	yield return new WaitForSeconds(0);
}

void OnTriggerEnter(Collider other) 
{
        if (other.CompareTag("BadTrigger"))
        {
		StartCoroutine(Wait());
		GameObject.Find("Player").transform.position = game_controller.GetComponent<Objectives>().respawn_puzzle_1.transform.position;
		GameObject.Find("ScreenFade").GetComponent<Animator>().Play("SCREEN_FADE_IN");
		errorcounter = errorcounter + 30;
		GameObject.Find("Line1").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line2").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line3").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line4").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line5").GetComponent<Animator>().SetBool("Line", false);
		game_controller.GetComponent<Objectives>().objective_puzzle_1 = 0;		
        } 

        if (other.CompareTag("GoodTrigger"))
        {
			GameObject.Find("SOUND").GetComponent<AudioSource>().Play();
            Transform line = other.GetComponentInParent<Transform>();
			Transform liner = line.parent;
			BoxCollider[] unchecker = liner.GetComponentsInChildren<BoxCollider>();
			ColorSwap[] colorchecker = liner.GetComponentsInChildren<ColorSwap>();
			foreach(ColorSwap colorcheck in colorchecker)
			{
				colorcheck.check = true;
			}
			foreach(BoxCollider uncheck in unchecker)
			{
				uncheck.enabled = false;
			}
			game_controller.GetComponent<Objectives>().objective_puzzle_1++;
			if(liner.name == "Line1")
			{
				ColorSwapSymbols symbol = GameObject.Find("Symbol_Line_1").GetComponentInChildren<ColorSwapSymbols>();
				symbol.symbolcolor = true;
				
			}
			if(liner.name == "Line2")
			{
				ColorSwapSymbols symbol = GameObject.Find("Symbol_Line_2").GetComponentInChildren<ColorSwapSymbols>();
				symbol.symbolcolor = true;
				
			}
			if(liner.name == "Line3")
			{
				ColorSwapSymbols symbol = GameObject.Find("Symbol_Line_3").GetComponentInChildren<ColorSwapSymbols>();
				symbol.symbolcolor = true;
				
			}
			if(liner.name == "Line4")
			{
				ColorSwapSymbols symbol = GameObject.Find("Symbol_Line_4").GetComponentInChildren<ColorSwapSymbols>();
				symbol.symbolcolor = true;
				
			}
			if(liner.name == "Line5")
			{
				ColorSwapSymbols symbol = GameObject.Find("Symbol_Line_5").GetComponentInChildren<ColorSwapSymbols>();
				symbol.symbolcolor = true;
				
			}
        }

		   

}


}
