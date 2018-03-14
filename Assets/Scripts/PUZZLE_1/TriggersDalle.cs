using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersDalle : MonoBehaviour
{

    void OnTriggerEnter(Collider player)
    {
         if(this.CompareTag("GoodTrigger"))
        {
            //Rajouter un feedback de réussite
            this.transform.parent.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<Objectives>().objective_puzzle_1 = GameObject.Find("Player").GetComponent<Objectives>().objective_puzzle_1 + 1;

        }
    }
}
