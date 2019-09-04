using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfiles : Photon.MonoBehaviour
{
    public static int playerGold;
    public static int playerHealth;
    public Text playerGoldText;
    public Text playerHealthText;
    public Card[] myCard;

    public static GameObject LocalPlayerInstance;
    public PlayerProfiles OppositePlayer;
    public bool IsLocalPlayer { get; set; }
    public byte NetworkId { get; set; }


    private void Awake()
    {
        playerGold = 0;
        playerHealth = 14440;
        if (photonView.isMine)
        {
            PlayerProfiles.LocalPlayerInstance = this.gameObject;
        }
    }

    void Update()
    {
        //playerGoldText.text = playerGold.ToString();
        //playerHealthText.text = playerHealth.ToString();
    }
}
