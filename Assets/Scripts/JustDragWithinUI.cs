using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JustDragWithinUI : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
    }
}
