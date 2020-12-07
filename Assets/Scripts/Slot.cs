using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{   
    private DragDrop itemDrag;
    public DragDrop ItemDrag {get => itemDrag; }

    private bool filled = false;
    public bool Filled {set => filled = value; }
    public bool AddItem(GameObject item)
    {
        if(!filled)
        {
            GameObject clone = Instantiate(item, this.transform.position, Quaternion.identity, this.transform);
            itemDrag = clone.GetComponent<DragDrop>();
            Destroy(item);
            filled = true;
            return true;
        }
        return false;
    }
    // public bool RemoveItem(GameObject item)
    // {

    // }
}
