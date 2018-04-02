using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapSymbols : MonoBehaviour 
{
	private Renderer rend;
	public bool symbolcolor;
	public bool activate;

	void Start () 
	{
		rend = GetComponent<Renderer>();
	}
	
	void Update () 
	{

		activate = GameObject.Find ("Player").GetComponent<TriggersPlayer> ().activate;
		if (activate == false) {
			rend.material.SetColor ("_Color", Color.clear);
			rend.material.SetColor ("_MKGlowTexColor", Color.clear);
			rend.material.SetColor ("_MKGlowColor", Color.clear);
		} else {
			rend.material.SetColor ("_Color", Color.white);
			rend.material.SetColor ("_MKGlowTexColor", Color.white);
			rend.material.SetColor ("_MKGlowColor", Color.white);
		}

		if(symbolcolor == true && activate == true)
		{
			rend.material.SetColor ("_Color", Color.cyan);
			rend.material.SetColor ("_MKGlowTexColor", Color.cyan);
			rend.material.SetColor ("_MKGlowColor", Color.cyan);
		}

	}
}
