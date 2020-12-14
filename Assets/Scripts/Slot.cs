using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{   
    private DragDrop itemDrag;
    public DragDrop ItemDrag {get => itemDrag; }

    private string itemName = "";
    public string ItemName {get => itemName; set => itemName = value; }

    private bool filled = false;
    public bool Filled {get => filled; set => filled = value; }
    public bool AddItem(GameObject item)
    {
        ///clones the original sprite into the inventory UI or locking UI area
        if(!filled)
        {
            GameObject clone = Instantiate(item, this.transform.position, Quaternion.identity, this.transform);
            itemDrag = clone.GetComponent<DragDrop>();
            clone.name = item.name;
            itemName = item.name;
            Destroy(item);
            filled = true;
            return true;
        }
        return false;
    }

    public bool LockItem(GameObject item)
    {
        ///clones the original sprite into the inventory UI or locking UI area
        Debug.Log(filled);
        if(!filled)
        {
            GameObject clone = Instantiate(item, this.transform.position, Quaternion.identity, this.transform);
            itemDrag = clone.GetComponent<DragDrop>();
            itemDrag.CanDrag = false;
            clone.name = item.name;
            itemName = item.name;
            Destroy(item);
            filled = true;
            return true;
        }
        return false;
    }
}
