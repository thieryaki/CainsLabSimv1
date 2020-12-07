using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private Rigidbody2D rb;

    private bool canDrag = true;
    public bool CanDrag {get => canDrag; set => canDrag = value; }

    private bool changeToUIParent = false;
    private Transform UI;

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up");
        Debug.Log(changeToUIParent);
        if (changeToUIParent) {
            Debug.Log("changes to UI parent");
            canDrag = true;
            changeToUIParent = false;
            rb.gravityScale = 20;
            Instantiate(this, this.transform.position, Quaternion.identity, UI);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("enters trigger");
        if (coll.transform.CompareTag("slot"))
        {
            Debug.Log("enters slot");
            Slot s = coll.gameObject.GetComponent<Slot>();
            rb.gravityScale = 0;
            bool success = s.AddItem(this.gameObject);
        }
        if (coll.transform.CompareTag("UI"))
        {
            Debug.Log("enters UI");
            Debug.Log(changeToUIParent);
            Debug.Log(UI);
            changeToUIParent = true;
            UI = coll.gameObject.transform;
            Debug.Log(changeToUIParent);
            Debug.Log(UI);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("slot"))
        {
            Slot s = coll.gameObject.GetComponent<Slot>();
            s.Filled = false;
        }
    }

}
