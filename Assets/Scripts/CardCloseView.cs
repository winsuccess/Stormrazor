using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardCloseView : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public GameObject viewCard;
    CardDisplay cd;

    private void Start()
    {
        panel = GameObject.Find("Screen Overlay Canvas/ClosePanel");
        viewCard = GameObject.Find("Screen Overlay Canvas/ViewCard");
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {

            viewCard.GetComponent<CanvasGroup>().alpha = 0;
            viewCard.GetComponent<CanvasGroup>().blocksRaycasts = false;
            Debug.Log(name + " Game Object Clicked!");
    }
}
