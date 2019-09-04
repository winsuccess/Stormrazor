using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public GameObject viewCard;
    public CardStats cs;

    private void Start()
    {
        panel = GameObject.Find("Screen Overlay Canvas/ClosePanel");
        viewCard = GameObject.Find("Screen Overlay Canvas/ViewCard");
        cs = GetComponent<CardStats>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        viewCard.GetComponent<CardDisplay>().DisplayView(cs);
        viewCard.GetComponent<CanvasGroup>().alpha = 1;
        viewCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log(name + " Game Object Clicked!");
    }

}
