using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private Rigidbody2D rb;

    ///this script is applied to each object
    ///canDrag indicates whether an individual object can be dragged or not
    private bool canDrag = true;
    public bool CanDrag {get => canDrag; set => canDrag = value; }

    ///this determines if there is a need to set the new parent location of the dragable object to the UI it is being dragged into 
    private bool changeToUIParent = false;
    private Transform UI;
    #region dragsObject
    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        }
    }
    #endregion
    #region OnPointerDown
    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }
    #endregion
    public void OnPointerUp(PointerEventData eventData)
    {
        if (changeToUIParent) {
            canDrag = true;
            changeToUIParent = false;
            rb.gravityScale = 20;
            Instantiate(this, this.transform.position, Quaternion.identity, UI);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        ///checks if object is being dragged into an open inventory slot and determines if it is already filled or not
        if (coll.transform.CompareTag("slot"))
        {
            
            Slot s = coll.gameObject.GetComponent<Slot>();
        
            rb.gravityScale = 0;
            s.AddItem(this.gameObject);
        }
        ///checks if an object from the inventory is being dragged into the canvas UI, if it is then it duplicates the objects into this UI and changes gravity
        if (coll.transform.CompareTag("UI"))
        {
            changeToUIParent = true;
            UI = coll.gameObject.transform;
        }
        ///if beaker is put into the beaker Lock UI, then lock it until it reaches a certain water thresh-hold
        if (this.transform.CompareTag("Beaker") && coll.transform.CompareTag("BeakerLock"))
        {
            Slot s = coll.gameObject.GetComponent<Slot>();
        
            s.LockItem(this.gameObject);
        }

        if (this.transform.CompareTag("Erlynmeyer") && coll.transform.CompareTag("TitrationLock1"))
        {
            Slot s = coll.gameObject.GetComponent<Slot>();
        
            s.LockItem(this.gameObject);
        }

        if (this.transform.CompareTag("Funnel") && coll.transform.CompareTag("TitrationLock2"))
        {
            Slot s = coll.gameObject.GetComponent<Slot>();
        
            s.LockItem(this.gameObject);
        }

        if (this.transform.CompareTag("NaOH Beaker") && coll.transform.CompareTag("TitrationLock3"))
        {
            Slot s = coll.gameObject.GetComponent<Slot>();
        
            s.LockItem(this.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        Slot s = coll.gameObject.GetComponent<Slot>();
        if (coll.transform.CompareTag("slot") && this.name == s.ItemName)
        {
            s.Filled = false;
        }

        if (coll.transform.CompareTag("BeakerLock") && this.name == s.ItemName)
        {
            s.Filled = false;
        }
        
    }

}
