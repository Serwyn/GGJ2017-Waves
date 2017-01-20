using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int moveSpeed;
    public int jumpForce;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("HorizontalMove"))
        {
            horizontalMove();
        }
        else { rb.velocity = Vector2.zero; };

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch();
        }
	}

    public void horizontalMove()
    {
        rb.velocity = new Vector2(1, 0) * Input.GetAxis("HorizontalMove") * moveSpeed;
    }

    public void jump()
    {
        rb.AddForce(new Vector2(0, 1) * jumpForce);
    }

    public void crouch()
    {

    }

}
