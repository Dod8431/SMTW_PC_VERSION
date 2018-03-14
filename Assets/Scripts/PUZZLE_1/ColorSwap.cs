using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour 
{
private Renderer rend;
public Color color_blue;
public bool check;
private bool end = false;
public GameObject red_particle;
public GameObject blue_particle;
private Animator anim;


		void Start () 
		{
			rend = GetComponentInChildren<Renderer>();
			anim = GetComponentInParent<Animator>();
		}
	
	void Update () 
	{
		if(check == true & end == false)
		{
			rend.materials[1].color = color_blue;
			red_particle.SetActive(false);
			blue_particle.SetActive(true);
			anim.SetBool("Line", true);
			end = true;
		}

	}
}
