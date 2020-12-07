using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void Update()   
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
    // Start is called before the first frame update

}
