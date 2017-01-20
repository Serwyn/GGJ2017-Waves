using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float maxSpeed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (true)
        {
            if (Input.GetButton("HorizontalMove"))
            {
                horizontalMove();
            }
            else
            {
                //stop move
            };

            if (Input.GetButtonDown("Jump"))
            {
                jump();
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch();
            }
        }
        else
        {
            //set Velocity
        }
	}

    public void horizontalMove()
    {
        rb.velocity =new Vector2(0, rb.velocity.y) + Vector2.right * Input.GetAxisRaw("HorizontalMove") * moveSpeed;
    }

    public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0) + Vector2.up * jumpForce;
    }

    public void crouch()
    {

    }

}
