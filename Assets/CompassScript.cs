using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour {

    public Vector3 NorthDirection;
    public Transform Player;
    public Quaternion MissionDirection;

    public RectTransform Northlayer;


	void Update ()
    {
        ChangeNorthDirection();
	}

    public void ChangeNorthDirection()
    {
        NorthDirection.z = -Player.eulerAngles.y;
        Northlayer.localEulerAngles = NorthDirection;
    }

}
