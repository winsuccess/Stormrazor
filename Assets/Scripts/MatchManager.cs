using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public string gameType;
    public List<Card> cardList;
    private void Awake()
    {
        gameType = GameManager.instance.gameType;
        if (gameType == "single")
        {
            PlayerManager.instance.AddSingleplayer();
            AIManager.instance.AddAI();
        }
        else if (gameType == "multi")
        {

        }
        Card[] cards = Resources.LoadAll<Card>("Champions");
        foreach (Card c in cards)
            cardList.Add(c);
    }
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}
