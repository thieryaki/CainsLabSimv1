using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weight : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    void Update()
    {
        if(sumWeight < .2 && sumWeight > .12)
        {
            display.color = Color.green;
        } 
        else
        {
            display.color = Color.red;
        }
    }

    private float sumWeight;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        sumWeight += coll.gameObject.GetComponent<Rigidbody2D>().mass;
        display.text = sumWeight + "g";
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        sumWeight -= coll.gameObject.GetComponent<Rigidbody2D>().mass;
        display.text = sumWeight + "g";
    }
}
