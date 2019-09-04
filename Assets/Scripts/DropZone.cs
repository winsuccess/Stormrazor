using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler
{
    public enum Position { Hand, BottomLeft, BottomRight, MidLeft, MidRight, Center };
    public Position pos;

    public void OnDrop(PointerEventData data)
    {
        if (pos == Position.Hand || this.transform.childCount == 0)
        {
            Draggable drg = data.pointerDrag.GetComponent<Draggable>();
            if (drg != null)
            {
                drg.currentParent = this.transform;
                if (pos != Position.Hand)
                {
                    drg.OnEndDrag(data);
                    data.pointerDrag.transform.localScale = new Vector3(2, 2, 2);
                    data.pointerDrag.transform.localPosition = Vector3.one;
                    data.pointerDrag.transform.localRotation = Quaternion.identity;
                }
            }
            Debug.Log("Drop to " + this.name);
        }
    }
}


