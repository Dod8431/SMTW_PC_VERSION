using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushingPillars : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public string good_symbol;

    void FixedUpdate()
    {
        Debug.DrawRay (transform.position, Vector3.forward * 5, Color.green);
    }

    /*void OnTriggerStay(Collider player)
    {
        if (this.CompareTag("Front") && player.CompareTag("Player_Mark"))
        {

            if(Input.GetButton("Use"))
            {
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                if(Physics.Raycast(transform.position, fwd, 2))
                {
                    Debug.DrawRay (transform.position, Vector3.forward * 2, Color.green);
                    print("Forward");
                }
                
            }

        }

        if (this.CompareTag("Back") && player.CompareTag("Player_Mark"))
        {

            if (Input.GetButton("Use"))
            {
                Vector3 bck = transform.TransformDirection(Vector3.back);
                if(Physics.Raycast(transform.position, bck, 2))
                {
                    Debug.DrawRay (transform.position, Vector3.back * 2, Color.green);
                    print("Back");
                }
            }
        }

        if (this.CompareTag("Right") && player.CompareTag("Player_Mark"))
        {

            if (Input.GetButton("Use"))
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                Vector3 lft = transform.TransformDirection(Vector3.left);
                if(Physics.Raycast(transform.position, lft, 2))
                {
                    Debug.DrawRay (transform.position, Vector3.left * 2, Color.green);
                    print("Left");
                }
            }
        }

        if (this.CompareTag("Left") && player.CompareTag("Player_Mark"))
        {

            if (Input.GetButton("Use"))
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                Vector3 rht = transform.TransformDirection(Vector3.right);
                if(Physics.Raycast(transform.position, rht, 2))
                {
                    Debug.DrawRay (transform.position, Vector3.right * 2, Color.green);
                    print("Right");
                }
            }
        }


    }
    */

    /*void OnTriggerEnter(Collider zoneblock)
    {
        if (this.CompareTag("Zone_To_Block") && zoneblock.CompareTag("Zone_Block"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (this.CompareTag("Zone_To_Block") && zoneblock.CompareTag(good_symbol)) //Bon pillier
        {
            //Animation encastrement pillier
            GameObject.Find("Player").GetComponent<Objectives>().objective_puzzle_2++;
        }
    }
    */
}
