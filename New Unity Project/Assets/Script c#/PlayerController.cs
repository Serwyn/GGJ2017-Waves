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
            HorizontalMove();
        }

        if (Input.GetButtonDown("jump"))
        {
            jump();
        }

        if (Input.GetButtonDown("crouch"))
        {
            crouch();
        }
	}

    public void HorizontalMove()
    {
        
    }

    public void jump()
    {

    }

    public void crouch()
    {

    }

}
