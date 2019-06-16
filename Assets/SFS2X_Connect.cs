using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using TMPro;

public class SFS2X_Connect : MonoBehaviour
{
    public string ConfigFile = "sfs-config.xml";
    public bool UseConfigFile = false;

    //Connection system
    public string ServerIP = "127.0.0.1";
    public int ServerPort = 9933;

    //Zones system
    public string ZoneName = "SMTW_ZONE";
    public string UserName = "";

    //Room system
    public string RoomName = "";
    public TMP_InputField RoomCode;
    public RoomSettings RoomSettings;

    SmartFox sfs;

    public void Connect()
    {
        sfs = new SmartFox();
        sfs.ThreadSafeMode = true;

        sfs.AddEventListener(SFSEvent.CONNECTION, OnConnection);
        sfs.AddEventListener(SFSEvent.LOGIN, OnLogin);
        sfs.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
        sfs.AddEventListener(SFSEvent.CONFIG_LOAD_SUCCESS, OnConfigLoad);
        sfs.AddEventListener(SFSEvent.CONFIG_LOAD_FAILURE, OnConfigFail);
        sfs.AddEventListener(SFSEvent.ROOM_JOIN, OnJoinRoom);
        sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomError);

        RoomName = RoomCode.text;

        if (UseConfigFile)
        {
            sfs.LoadConfig(Application.dataPath + "/" + ConfigFile);
        } else {
            sfs.Connect(ServerIP, ServerPort);
        }

        
    }

    void OnConfigLoad(BaseEvent e)
    {
        Debug.Log("Configuration file loaded");
        sfs.Connect(sfs.Config.Host, sfs.Config.Port);
    }

    void OnConfigFail (BaseEvent e)
    {
        Debug.Log("Failed to load configuration file");
    }

    void OnLogin(BaseEvent e)
    {
        Debug.Log("Logged in: " + e.Params["user"]);
        sfs.Send(new JoinRoomRequest(RoomName));
    }

    void OnJoinRoom(BaseEvent e)
    {
        Debug.Log("Joined Room: " + e.Params["room"]);
    }

    void OnJoinRoomError(BaseEvent e)
    {
        Debug.Log("JoinRoom Error" + e.Params["errorCode"] + e.Params["errorMessage"]);
    }

    void OnLoginError(BaseEvent e)
    {
        Debug.Log("Login error: " + e.Params["errorCode"] + e.Params["errorMessage"]);
    }

    void OnConnection(BaseEvent e)
    {
        if((bool)e.Params["success"])
        {
            Debug.Log("Successfully connected");
            if (UseConfigFile)
            {
                ZoneName = sfs.Config.Zone;
            }
            sfs.Send(new LoginRequest(UserName, "", ZoneName));
        } else {
            Debug.Log("Connection failed");
        }
    }

    void Update()
    {
        sfs.ProcessEvents();
    }

    void OnApplicationQuit()
    {
        if(sfs.IsConnected)
        {
            sfs.Disconnect();
        }
    }
}
