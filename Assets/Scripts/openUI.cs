using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUI : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;


    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private Slot slot1;

    [SerializeField]
    private Slot slot2;

    private bool playerNear = false;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

    void Update()
    {
        if (playerNear && Input.GetKey("e"))
        {
            Player.SetActive(false);
            ui.SetActive(true);
            player.CanMove = false;
            DragDrop d1 = slot1.ItemDrag;
            if (d1 != null) {
                d1.CanDrag = true;
            }
            DragDrop d2 = slot2.ItemDrag;
            if (d2 != null){
                d2.CanDrag = true;
            }
        }

        if (Input.GetKey("escape"))
        {
            Player.SetActive(true);
            ui.SetActive(false);
            player.CanMove = true;
            DragDrop d1 = slot1.ItemDrag;
            if (d1 != null) {
                d1.CanDrag = false;
            }
            DragDrop d2 = slot2.ItemDrag;
            if (d2 != null){
                d2.CanDrag = true;
            }
        }
    }


}
