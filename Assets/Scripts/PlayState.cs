using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayState : MonoBehaviour
{
    public enum State { FirstState, DrawState, FreeState, LockState, BattleState };
    public State state;
    public int round;

    public MatchManager mm;

    public Transform card;
    public Transform myHand;
    public Transform aiHand;
    public Transform opponentHand;
    public Transform drawCards;
    public Transform myCardsDown;
    public Transform enemyCardsDown;
    public Transform myDeck;
    public Transform lockDeck;
    public Transform blockRaycast;
    public List<Card> cardList;
    public static int i = 0;

    void Start()
    {
        mm = this.GetComponent<MatchManager>();
        cardList = new List<Card>(mm.cardList);
        ChangeState(State.FirstState);
    }

    #region States
    public void ChangeState(State state)
    {
        this.state = state;
        switch (state)
        {

            case PlayState.State.FirstState:
                FirstState();
                break;
            case PlayState.State.LockState:
                LockState();
                break;
            case PlayState.State.DrawState:
                DrawState();
                break;
            case PlayState.State.FreeState:
                FreeState();
                break;
            case PlayState.State.BattleState:
                BattleState();
                break;
        }
    }

    public void FirstState()
    {
        Debug.Log("FIRST STATE");

        blockRaycast.SetSiblingIndex(drawCards.GetSiblingIndex());
        blockRaycast.GetComponent<CanvasGroup>().blocksRaycasts = true;

        for (int j = 1; j <= 10; j++)
        {
            int randomizeCard = Random.Range(0, cardList.Count);
            if(j%2 != 0)
                CardToHand(randomizeCard, drawCards);
            else

            {
                if(GameManager.instance.gameType == "single")
                    CardToHand(randomizeCard, aiHand);
                else if(GameManager.instance.gameType == "multi")
                    CardToHand(randomizeCard, opponentHand);
            }
            cardList.RemoveAt(randomizeCard);
        }
        StartCoroutine(DrawToHand());
    }

    public void DrawState()
    {
        if (drawCards.gameObject.activeSelf == false)
        {
            Debug.Log("DRAW STATE");
            drawCards.gameObject.SetActive(true);
            SetBlockRaycast(false, false, true, false);
        }
        else if (drawCards.childCount != 0)
        {

            drawCards.gameObject.SetActive(false);
            ChangeState(State.FreeState);
        }
        if (drawCards.childCount == 0)
        {
            for (int j = 1; j <= 3; ++j)
            {
                int randomizeCard = Random.Range(0, cardList.Count);
                Transform cloneCard;
                cloneCard = Instantiate(card, drawCards);
                cloneCard.GetComponent<CardStats>().card = cardList[randomizeCard];
                cloneCard.gameObject.AddComponent<BuyCard>();
                cloneCard.name = "Card" + i;
                i++;
            }
        }
    }

    public void FreeState()
    {
        Debug.Log("FREE STATE");

        blockRaycast.SetSiblingIndex(myHand.GetSiblingIndex());
        blockRaycast.GetComponent<CanvasGroup>().blocksRaycasts = false;
        SetInteractCard(true, true);
        SetBlockRaycast(true, true, true, true);
    }

    public void LockState()
    {
        Debug.Log("LOCK STATE");

        SetDropZone(false);
        SetBlockRaycast(true, true, false, false);
        if (GameManager.instance.gameType == "single")
        {
            int numputdown = 0;
            while(aiHand.childCount > 0 && numputdown <5)
            {
                int randomizeCard = Random.Range(0, aiHand.childCount);
                Transform aiCard = aiHand.GetChild(randomizeCard);
                aiCard.SetParent(enemyCardsDown.GetChild(numputdown));
                aiCard.localScale = new Vector3(2, 2, 2);
                aiCard.transform.localPosition = Vector3.one;
                aiCard.transform.localRotation = Quaternion.identity;
                numputdown++;
            }
        }
        else if (GameManager.instance.gameType == "multi")
        { }
            
        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            if (myCardsDown.GetChild(k).childCount != 0)
            {
                myCardsDown.GetChild(k).GetChild(0).GetComponent<Draggable>().enabled = false;
            }
        }
        ChangeState(State.BattleState);
    }

    public void BattleState()
    {
        Debug.Log("BATTLE STATE");

        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            if (myCardsDown.GetChild(k).childCount != 0)
            {
                GetComponent<GamePlayLogic>().myCard[k] = myCardsDown.GetChild(k).GetChild(0);
            }
        }

        for (int k = 0; k < enemyCardsDown.childCount; ++k)
        {
            if (enemyCardsDown.GetChild(k).childCount != 0)
            {
                GetComponent<GamePlayLogic>().enemyCard[k] = enemyCardsDown.GetChild(k).GetChild(0);
            }
        }

        GetComponent<GamePlayLogic>().InvokeRepeating("Fight", 0f, 2f);

        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            if (myCardsDown.GetChild(k).childCount != 0)
            {
                myCardsDown.GetChild(k).GetChild(0).GetComponent<Draggable>().enabled = false;
            }
        }


    }

    #endregion

    #region otherfunctions

    void CardToHand(int r,Transform pos)
    {
        Transform cloneCard;
        cloneCard = Instantiate(card, pos);
        cloneCard.GetComponent<CardStats>().card = cardList[r];
        cloneCard.name = cloneCard.GetComponent<CardStats>().card.name;
    }
    void SetInteractCard(bool h, bool d)
    {
        for (int k = 0; k < myHand.childCount; ++k)
        {
            myHand.GetChild(k).GetComponent<Draggable>().enabled = h;
            myHand.GetChild(k).GetComponent<CardView>().enabled = h;
        }

        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            if (myCardsDown.GetChild(k).childCount != 0)
            {
                myCardsDown.GetChild(k).GetChild(0).GetComponent<Draggable>().enabled = d;
                myCardsDown.GetChild(k).GetChild(0).GetComponent<CardView>().enabled = d;
            }
        }
    }

    void SetBlockRaycast(bool h, bool down, bool deck, bool l)
    {
        for (int k = 0; k < myHand.childCount; ++k)
        {
            myHand.GetChild(k).GetComponent<CanvasGroup>().blocksRaycasts = h;
        }
        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            if (myCardsDown.GetChild(k).childCount != 0)
                myCardsDown.GetChild(k).GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = down;
        }
        myDeck.GetComponent<CanvasGroup>().blocksRaycasts = deck;
        lockDeck.GetComponent<CanvasGroup>().blocksRaycasts = l;
    }

    void SetDropZone(bool dz)
    {
        for (int k = 0; k < myCardsDown.childCount; ++k)
        {
            myCardsDown.GetChild(k).GetComponent<DropZone>().enabled = dz;
        }
    }
    IEnumerator DrawToHand()
    {
        yield return new WaitForSeconds(1f);
        while (drawCards.childCount > 0)
        {
            Transform drawnCard = drawCards.GetChild(0);
            drawnCard.SetParent(myHand);
            drawnCard.localScale = Vector3.one;
            yield return new WaitForSeconds(0.5f);
        }
        ChangeState(State.FreeState);
    }
    #endregion
}
