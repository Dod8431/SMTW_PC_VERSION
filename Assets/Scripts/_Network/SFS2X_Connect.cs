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

	public bool awakeroomdoor = false;
	public float veaposx;
	public float veaposz;
	public bool narrative;

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
		ISFSObject AwkRoom_Door = (SFSObject)evt.Params ["message"];
		ISFSObject veapos = (SFSObject)evt.Params ["message"];
		veaposx = veapos.GetFloat ("PZ2Mazex");
		veaposz = veapos.GetFloat ("PZ2Mazez");
		awakeroomdoor = AwkRoom_Door.GetBool ("awakeroomopendoor");
		pz1controller.GetComponent<PZ1Controller> ().pz1entrancevalidate = pz1valid.GetBool ("pz1entrancecomplete");

	}

	public void ButtonPuzzle2_Send(string button, bool value)
	{
		ISFSObject ButtonP2 = new SFSObject ();
		ButtonP2.PutBool ("button", value);
		sfs.Send (new ObjectMessageRequest (ButtonP2));
	}

	void MainScene()
	{
		ISFSObject MainScene = new SFSObject ();
		MainScene.PutBool ("MainScene", true);
		MainScene.PutInt ("sceneIndex", 2);
		sfs.Send (new ObjectMessageRequest (MainScene));
	}

	void P1Entrance()
	{
		ISFSObject P1_Entrance = new SFSObject ();
		P1_Entrance.PutBool ("P1_Puzzle", true);
		P1_Entrance.PutInt ("sceneIndex", 5);
		sfs.Send (new ObjectMessageRequest (P1_Entrance));
	}

	void P1RiddleEntrance()
	{
		ISFSObject P1RiddleEntrance = new SFSObject ();
		P1RiddleEntrance.PutBool ("P1_Entrance", true);
		P1RiddleEntrance.PutInt ("sceneIndex", 4);
		sfs.Send (new ObjectMessageRequest (P1RiddleEntrance));
	}

	void P2Entrance()
	{
		ISFSObject P2Entrance = new SFSObject ();
		P2Entrance.PutBool ("P2_Puzzle", true);
		P2Entrance.PutInt ("sceneIndex", 6);
		sfs.Send (new ObjectMessageRequest (P2Entrance));
	}

	void P2MiniGame()
	{
		ISFSObject P2MiniGame = new SFSObject ();
		P2MiniGame.PutBool ("P2_Puzzle_Minigame", true);
		sfs.Send (new ObjectMessageRequest (P2MiniGame));
	}

	void Maze()
	{
		ISFSObject Maze = new SFSObject ();
		Maze.PutBool ("Maze", true);
		sfs.Send (new ObjectMessageRequest (Maze));
	}

	void AwakeRoomVeaNear()
	{
		ISFSObject markglow = new SFSObject ();
		markglow.PutBool ("markglow", true);
		sfs.Send (new ObjectMessageRequest (markglow));
	}

	public void Narrative(int narrative_index)
	{
		Debug.Log ("send");
		ISFSObject narrative = new SFSObject ();
		narrative.PutBool ("Narrative", true);
		narrative.PutInt ("narrativeIndex", narrative_index);
		narrative.PutInt ("sceneIndex", 3);
		sfs.Send (new ObjectMessageRequest (narrative));
	}

	public void CA_LoadScene(int index)
	{
		ISFSObject indexScene = new SFSObject ();
		indexScene.PutInt ("sceneIndex", index);
		sfs.Send (new ObjectMessageRequest (indexScene));
	}
}
