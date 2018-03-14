using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeaFollow : MonoBehaviour {
	
 public GameObject wayPoint;
 public bool check = false;
 private Vector3 wayPointPos;
 public float speed = 10.0f;
 public GameObject vea;
 public Animator anim;

 	void Start ()
 	{
      	wayPoint = GameObject.Find("Player");
	  	anim = this.GetComponent<Animator>();
 	}
 
 	void Update ()
 	{
		wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
     	transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);

 	}

}
