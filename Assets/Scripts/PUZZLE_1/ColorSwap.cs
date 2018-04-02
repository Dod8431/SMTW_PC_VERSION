using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour 
{
	private Renderer rend;
	public bool check;
	public Color glowcolor;
	private Animator anim;
	public bool activate;


		void Start () 
		{
			rend = GetComponentInChildren<Renderer>();
			anim = GetComponentInParent<Animator>();
			
		}
	
	void Update () 
	{

		activate = GameObject.Find ("Player").GetComponent<TriggersPlayer> ().activate;
		if (activate == false) {
			rend.materials [1].SetColor ("_MKGlowColor", Color.black);
			rend.materials [1].SetColor ("_MKGlowTexColor", Color.black);
			rend.materials [1].SetColor ("_Color", Color.black);
		} else {
			rend.materials [1].SetColor ("_MKGlowColor", Color.white);
			rend.materials [1].SetColor ("_MKGlowTexColor", Color.white);
			rend.materials [1].SetColor ("_Color", Color.white);
		}

		if(check == true && activate == true)
		{
			rend.materials [1].SetColor ("_MKGlowColor", Color.cyan);
			rend.materials [1].SetColor ("_MKGlowTexColor", glowcolor);
			rend.materials [1].SetColor ("_Color", Color.cyan);
			anim.SetBool("Line", true);
		}

	}
}
