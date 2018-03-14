using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject showbtntext;
    public GameObject door;
    Animator dooranimator;
    

    void Start()
    {
        dooranimator = door.GetComponent<Animator>();
    }

    void OnTriggerStay(Collider player)
    {
        if(player.CompareTag("Player_Mark"))
        {
            showbtntext.SetActive(true);
            GameObject.Find("Vea").GetComponent<Animator>().SetBool("Idle", false);
            GameObject.Find("Vea").GetComponent<Animator>().SetBool("Button", true);
            GameObject.Find("Vea").GetComponent<Transform>().SetParent(GameObject.Find("Player_Mark").GetComponent<Transform>());
            if (Input.GetButtonDown("Use"))
            {
                dooranimator.SetTrigger("Open");
            }
        
            
        }
            
    }

    void OnTriggerExit(Collider player)
    {
        if(player.CompareTag("Player_Mark"))
        {
            showbtntext.SetActive(false);
            GameObject.Find("Vea").GetComponent<Animator>().SetBool("Button", false);
            GameObject.Find("Vea").GetComponent<Animator>().SetBool("Idle", true);
            GameObject.Find("Vea").GetComponent<Transform>().SetParent(GameObject.Find("Player").GetComponent<Transform>());
        }
       
    }


}
