using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static bool UIopen = true;
    #region private Variables
    private float movementX;
    private float movementY;
    float tempmovementX = 0;
    float tempmovementY = 0;
    bool horizontalmovement = false;
    bool verticalmovement = false;
    private bool canMove = true;
    public bool CanMove {get => canMove; set => canMove = value; }

    Animator animation;
    int framecount = 60;
    #endregion
    //Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        animation = GetComponent<Animator>();

    }
    #region movement
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            movementY = Input.GetAxisRaw("Vertical");
            framecount++;

            if (horizontalmovement == true && framecount < 60)
            {
                Horizontalmove();
            }
            else if (verticalmovement == true && framecount < 60)
            {
                Verticalmove();
            }
            else if ((movementX != 0 || movementY != 0) && framecount >= 60)
            {
                horizontalmovement = false;
                verticalmovement = false;
                framecount = 0;
                Move();
            }
            else
            {
                animation.SetBool("moving", false);
                horizontalmovement = false;
                verticalmovement = false;    
            }
        }
    }

    void Move()
    {
        animation.SetBool("moving", true);
        tempmovementX = movementX;
        tempmovementY = movementY;
            
        if (movementX != 0)
        {
            animation.SetFloat("dirX", tempmovementX);
            animation.SetFloat("dirY", (-tempmovementX));         
            horizontalmovement = true;
        }
        else
        {
            animation.SetFloat("dirX", movementY);
            animation.SetFloat("dirY", movementY); 
            verticalmovement = true;
        }
    }

    void Verticalmove()
    {
        Vector2 pos;
        pos.x = this.transform.position.x + (float)(tempmovementY *.0049);
        pos.y = this.transform.position.y + (float)(tempmovementY * .0028);
        this.transform.position = pos;
    }

    void Horizontalmove()
    {
        Vector2 pos;
        pos.x = this.transform.position.x + (float)(tempmovementX * .0049);
        pos.y = this.transform.position.y + (float)(tempmovementX * -.0028);
        this.transform.position = pos;
    }
    #endregion
}
