using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {
public float pushdistance;
public float force;



	void Update()
	{
		RaycastHit hit;
		Vector3 direction = transform.forward;

		Debug.DrawRay (transform.position, direction * pushdistance, Color.magenta);


			if(Physics.Raycast(transform.position, direction, out hit))
			{
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("WaterPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("EarthPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("FirePil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("AirPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("LavaPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("IcePil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("PlantPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
				if (Physics.Raycast(transform.position, transform.forward, pushdistance) && hit.collider.CompareTag("SteamPil")) 
				{
					if(Input.GetButton("Use"))
					hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
				}
			}

	}
}
