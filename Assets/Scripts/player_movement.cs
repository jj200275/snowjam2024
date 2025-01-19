using System;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    private Boolean up;
    private Boolean down;
    private Boolean right;
    private Boolean left;
    private Vector2 my_velocity;
    public double max_velocity;
    private Rigidbody2D myBody;
    private SpriteRenderer mySprite;
    private Animator myAnimator;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                up = true;
            }
            else
            {
                up = false;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                down = true;
            }
            else
            {
                down = false;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                right = true;
            }
            else
            {
                right = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                left = true;
            }
            else
            {
                left = false;
            }
        }// Input Detection
        {
            my_velocity = Vector2.zero;
            if (up)
            {
                my_velocity.y += (float)max_velocity;
            }
            if (down)
            {
                my_velocity.y -= (float)max_velocity;
            }
            if (left)
            {
                my_velocity.x -= (float)max_velocity;
                mySprite.flipX = true;
            }
            if (right)
            {
                my_velocity.x += (float)max_velocity;
                mySprite.flipX = false;
            }
            if (Math.Abs(my_velocity.x) == Math.Abs(my_velocity.y))
            {
                my_velocity *= 0.707f;
            }
        }// Velocity calculation


        animateMyself();
        myBody.linearVelocity = my_velocity;
    }

    void animateMyself()
    {
        if(my_velocity != Vector2.zero)
        {
            myAnimator.SetBool("Walking", true);
        }
        else
        {
            myAnimator.SetBool("Walking", false);
        }
    }
}
