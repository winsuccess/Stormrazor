using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{
    NetworkManager networkManager;

    public GameObject roomPanel;
    public InputField createRoomInput, joinRoomInput;
    void Awake()
    {
        networkManager = Object.FindObjectOfType<NetworkManager>();
    }

    public void ConnectToPhoton()
    {
        networkManager.ConnectToPhoton();
        roomPanel.SetActive(true);

    }

    public void OnCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
            networkManager.CreateRoom(createRoomInput.text);
    }

    public void OnJoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomInput.text);
    }
}
