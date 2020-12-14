using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterSpout : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    public Transform waterDrop;
    
    [SerializeField]
    Transform UI;

    private int heldDownLength = 0;
    private bool press = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        press = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         press = true;
    }

    void Update()
    {
        if (press && heldDownLength < 360)
        {
            heldDownLength += 1;
            if (heldDownLength % 5 == 0)
            {
                float randomNum = Random.Range(475f, 500f);
                
                Vector3 newPosition = new Vector3(randomNum, 450f, 0f);
                Transform clone = Instantiate(waterDrop, newPosition, Quaternion.identity, UI);
            }   
        }
    }

}
