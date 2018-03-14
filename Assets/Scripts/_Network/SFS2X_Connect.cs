using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Entities.Variables;
using Sfs2X.Requests;
using Sfs2X.Logging;

public class SFS2X_Connect : MonoBehaviour {

	public string ServerIP = "127.0.0.1";
	public int ServerPort = 9933;
	public string ZoneName = "SMTW";
	public string UserName = "";
	public string RoomName = "Lobby";

	public GameObject pz1controller;

	SmartFox sfs;

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		sfs = new SmartFox ();
		sfs.ThreadSafeMode = true;

		sfs.AddEventListener (SFSEvent.CONNECTION, OnConnection);
		sfs.AddEventListener (SFSEvent.LOGIN, OnLogin);
		sfs.AddEventListener (SFSEvent.LOGIN_ERROR, OnLoginError);
		sfs.AddEventListener (SFSEvent.ROOM_JOIN, OnJoinRoom);
		sfs.AddEventListener (SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomError);
		sfs.AddEventListener (SFSEvent.OBJECT_MESSAGE, OnObjectMessage);

		sfs.Connect (ServerIP, ServerPort);
	}

	void OnLogin(BaseEvent evt)
	{
		Debug.Log ("Logged In: " + evt.Params ["user"]);
		sfs.Send (new JoinRoomRequest (RoomName));
	}

	void OnJoinRoom(BaseEvent evt)
	{
		Debug.Log ("Joined Room: " + evt.Params ["room"]);
	}

	void OnJoinRoomError(BaseEvent evt)
	{
		Debug.Log ("Join Room Error (" + evt.Params ["errorCode"] + "): " + evt.Params ["errorMessage"]);
	}

	void OnLoginError(BaseEvent evt)
	{
		Debug.Log ("Login error: (" + evt.Params ["errorCode"] + "): " + evt.Params ["errorMessage"]);
	}

	void OnConnection(BaseEvent evt)
	{
		if ((bool)evt.Params ["success"]) {
			Debug.Log ("Successfully Connected");
			sfs.Send (new LoginRequest (UserName, "", ZoneName));
		} else {
			Debug.Log ("Connection Failed");
		}
	}

	void Update()
	{
		sfs.ProcessEvents ();
	}

	void OnApplicationQuit()
	{
		if (sfs.IsConnected) {
			sfs.Disconnect ();
		}
	}

	void OnObjectMessage(BaseEvent evt)
	{
		ISFSObject pz1valid = (SFSObject)evt.Params ["message"];
		pz1controller.GetComponent<PZ1Controller> ().pz1entrancevalidate = pz1valid.GetBool ("pz1entrancecomplete");

	}

	void P1Entrance()
	{
		ISFSObject P1_Entrance = new SFSObject ();
		P1_Entrance.PutBool ("check", true);
		sfs.Send (new ObjectMessageRequest (P1_Entrance));
		Debug.Log ("cc");
	}
}
