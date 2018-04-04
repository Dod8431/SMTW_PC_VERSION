using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;

public class TriggersPlayer : MonoBehaviour 
{

	public GameObject pz1_controller;
	private Transform symbol;
	public Color symbolcolorpicker;
	private GameObject m_Player;
	public Transform m_Respawn;
	public bool activate;
	public GameObject error_sfx_puzzle_1;

	void Start()
	{
		m_Player = GameObject.Find ("Player");
		pz1_controller = GameObject.Find("Puzzle_1_Controller");
	}

	IEnumerator Wait(Transform respawn)
	{
		error_sfx_puzzle_1.SetActive (true);
		GameObject.Find("ScreenFade").GetComponent<Animator>().Play("FadeIn");
		yield return new WaitForSeconds(0.3f);
		m_Player.transform.position = respawn.position;
		yield return new WaitForSeconds(0.3f);
		GameObject.Find("Line1").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line2").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line3").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line4").GetComponent<Animator>().SetBool("Line", false);
		GameObject.Find("Line5").GetComponent<Animator>().SetBool("Line", false);
		pz1_controller.GetComponent<Objectives>().objective_puzzle_1 = 0;	
		pz1_controller.GetComponent<Objectives>().Puzzle_1_Generator();
		yield return new WaitForSeconds (1.2f);
		GameObject.Find("ScreenFade").GetComponent<Animator>().Play("FadeOut");
		yield return new WaitForSeconds (0.2f);
		error_sfx_puzzle_1.SetActive (false);

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("BadTrigger") && activate == true)
        {
			StartCoroutine(Wait(m_Respawn));
        } 

		if (other.CompareTag("GoodTrigger") && activate == true)
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
				pz1_controller.GetComponent<Objectives>().objective_puzzle_1++;

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
