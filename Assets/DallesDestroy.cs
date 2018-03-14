using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DallesDestroy : MonoBehaviour {

    public GameObject parent;

	void OnTriggerExit(Collider other)
    {
        Debug.Log("ok");
        StartCoroutine(ExitAndDestroy());
    }

    IEnumerator ExitAndDestroy()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(parent);
    }
}
