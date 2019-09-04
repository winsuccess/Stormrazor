using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform currentParent;
    private GameObject placeHolder = null;
    public GameObject canvas;
    private bool onHand;

    void Start()
    {
        currentParent = GameObject.Find("Hand").transform;
        onHand = true;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("On Begin Drag");
        canvas = GameObject.Find("Screen Overlay Canvas");

        if (onHand)
        {
            placeHolder = new GameObject();
            placeHolder.name = "PlaceHolder";
            placeHolder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeHolder.AddComponent<LayoutElement>();
            RectTransform rt = le.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(80, 160);
            placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            this.transform.SetParent(canvas.transform);
        }
        else if (!onHand)
        {
            this.transform.SetParent(canvas.transform);
            Debug.Log("Move from table to hand!");
            this.transform.localPosition = Vector3.one;
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            data.pointerDrag.transform.localRotation = Quaternion.identity;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (onHand)
        {
            int newSiblingIndex = currentParent.childCount;
            for (int i = 0; i < currentParent.childCount; i++)
            {
                if (this.transform.position.x < currentParent.GetChild(i).position.x && this.transform.position.y <= (currentParent.position.y+300))
                {
                    newSiblingIndex = i;
                    if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;
                    break;
                }
            }
            placeHolder.transform.SetSiblingIndex(newSiblingIndex);
        }

        this.transform.position = data.position;
    }
    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("On End Drag");
        this.transform.SetParent(currentParent);
        if (currentParent != GameObject.Find("Hand").transform)
        {
            data.pointerDrag.transform.localScale = new Vector3(2, 2, 2);
            data.pointerDrag.transform.localPosition = Vector3.one;
            data.pointerDrag.transform.localRotation = Quaternion.identity;
            onHand = false;
        }
        else
            onHand = true;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (placeHolder != null)
        {
            this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            Destroy(placeHolder);
        }


    }
}
