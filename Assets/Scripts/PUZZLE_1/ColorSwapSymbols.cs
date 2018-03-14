using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapSymbols : MonoBehaviour 
{
public Renderer rend;
public Color color_blue;
public bool symbolcolor;
private bool end = false;
private Shader yolo;


		void Start () 
		{
			rend = GetComponent<Renderer>();
		}
	
	void Update () 
	{
		if(symbolcolor == true & end == false)
		{
			rend.material.SetColor( "_Color", Color.cyan); 
			end = true;
		}

	}
}
