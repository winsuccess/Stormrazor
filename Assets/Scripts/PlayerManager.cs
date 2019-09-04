using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Photon.PunBehaviour
{
    public static PlayerManager instance = null;
    public GameObject player;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddMultiplayer()
    {
            Debug.Log("We are Instantiating LocalPlayer");
        PhotonNetwork.Instantiate("Player", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }

    public void AddSingleplayer()
    {
        Debug.Log("We are Instantiating Singleplayer");
        Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void SetPlayerStats()
    {

    }

    public void SetCamera()
    {
        if (PhotonNetwork.isMasterClient)
        {
            var p2Rotation = Quaternion.Euler(0f, 0f, 180f);

            Camera.main.transform.rotation = p2Rotation;

        }
        else
        {
            Camera.main.transform.rotation = Quaternion.identity;
        }
    }

}
