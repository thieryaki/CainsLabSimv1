using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterBottle : MonoBehaviour
{
    [SerializeField]
    private Slot beakerlock;

    [SerializeField]
    private GameObject slider;

    public int waterCount = 0;
    public int WaterCount {get => waterCount; }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "droplet")
        {
            Destroy(coll.gameObject);
            waterCount++;
            WaterBar s = slider.gameObject.GetComponent<WaterBar>();
            s.TargetProgress += .5f;

        }

        if (waterCount == 72)
        {
            DragDrop drag = beakerlock.ItemDrag;
            drag.CanDrag = true;
        }
    }
}