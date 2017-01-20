using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float maxSpeed;
    Rigidbody rb;
    PlayerState playerState;

    public string HorizontalMove;
    public string Jump;
    public string Crouch;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(HorizontalMove))
        {
            horizontalMove();
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        };

        if (Input.GetButtonDown(Jump))
        {
            jump();
        }

        if (Input.GetButtonDown(Crouch))
        {
            crouch();
        }
    }

    public void horizontalMove()
    {
        rb.velocity =new Vector3(0, rb.velocity.y, 0) + Vector3.right * Input.GetAxisRaw(HorizontalMove) * moveSpeed;
    }

    public void jump()
    {
        if (playerState.isLanded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0) + Vector3.up * jumpForce;
            playerState.isLanded = false;
        }
    }

    public void crouch()
    {

    }

}
