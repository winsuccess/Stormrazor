using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon;

public class NetworkManager : Photon.PunBehaviour
{
    public static NetworkManager instance = null;

    private string versionName = "0.1";
    private PlayerProfiles Player1 { get; set; }
    private PlayerProfiles Player2 { get; set; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        PhotonNetwork.automaticallySyncScene = true;
    }

    void Start()
    {
        
    }

    #region Functions
    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to Photon...");
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomName, ro, TypedLobby.Default);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Ingame");
        GameManager.beginGame = true;
    }


    #endregion

    #region PunBehavior
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Photon");
    }

    public override void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        base.OnFailedToConnectToPhoton(cause);
        Debug.Log("Failed to connect to Photon...");
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        base.OnPhotonJoinRoomFailed(codeAndMsg);
        Debug.Log("Failed to join the room");
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created A Room");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby!");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Photon Room, Waiting for Players...");
    }

    public override void OnDisconnectedFromPhoton()
    {
        base.OnDisconnectedFromPhoton();
        Debug.Log("Disconected from Photon...");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("LEFT THE ROOM!");
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        base.OnPhotonPlayerConnected(newPlayer);
        Debug.Log("New Player has Connected, Starting Game...");
        if (PhotonNetwork.isMasterClient)
        {   
            if(PhotonNetwork.playerList.Length > 1)
            {
                PhotonNetwork.room.IsOpen = false;
                StartGame(); 
            }
        }
    }
    #endregion
}
