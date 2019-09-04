using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyCard : MonoBehaviour, IPointerClickHandler
{
    public Transform hand;
    void Start()
    {
        hand = GameObject.Find("Hand").transform;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerProfiles.playerGold >= 450)
        {
            PlayerProfiles.playerGold -= 450;
            this.transform.SetParent(hand);
            this.transform.localScale = Vector3.one;
        }

    }

}
