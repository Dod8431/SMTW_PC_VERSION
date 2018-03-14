using UnityEngine;

public class Pickup : MonoBehaviour 
{
	public GameObject pickuptext;
	public GameObject playerhand;
	public bool pick;
	public bool picked;
	void FixedUpdate()
	{
		pickuptext.SetActive(false);
		RaycastHit hit;
		Vector3 direction = transform.forward;
		Debug.DrawRay (transform.position, direction * 5, Color.red);
		pick = false;

		if(Physics.Raycast(transform.position, direction, out hit) && hit.transform.tag == "Pickup" && picked == false)
			{
				if (Physics.Raycast(transform.position, transform.forward, 5)) 
				{
					pickuptext.SetActive(true);
					pick = true;
				}
			}

			if(Physics.Raycast(transform.position, direction, out hit) && hit.transform.tag == "Spike_Dez" && picked == false)
			{
				if (Physics.Raycast(transform.position, transform.forward, 5)) 
				{
					hit.transform.GetComponent<SpikeDez>().outlined = true;
					if(Input.GetButton("Use") && hit.transform.tag == "Spike_Dez")
					{
						hit.transform.GetComponent<SpikeDez>().desactivated = true;
					}

				}
			}

		if(Input.GetButton("Use") && pick == true && picked == false)
			{
				hit.transform.tag = "Picked";
				// hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
				hit.transform.gameObject.GetComponent<Rigidbody>().Sleep();
				hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
				hit.transform.parent = playerhand.transform;
				hit.transform.localScale = Vector3.one * 0.5f;
				//hit.transform.position = playerhand.transform.position;
				picked = true;
			}

		if(Input.GetKey(KeyCode.Joystick1Button1) && picked == true)
			{
				Transform pickup = playerhand.GetComponentInChildren<Transform>().GetChild(0);
				pickup.tag = "Pickup";
				// pickup.GetComponent<Rigidbody>().useGravity = true;
				pickup.GetComponent<BoxCollider>().enabled = true;
				pickup.GetComponent<Rigidbody>().WakeUp();
				pickup.parent = null;
				pickup.localScale = Vector3.one;
				picked = false;
			}

	}

}

