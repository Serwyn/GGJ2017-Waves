using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float maxSpeed;
    Rigidbody rb;
    PlayerState playerState;
    public GameObject otherPlayer;
    public Sprite crouchedSprite;
    public Sprite normalSprite;
    public Sprite jumpSprite;

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
            horizontalMove(true);
        }
        else if (Input.GetButtonUp(HorizontalMove))
        {
            horizontalMove(false);
        }

        
        else if (playerState.isLanded && !playerState.isCrouched)
        {
            this.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
        };
        if (Input.GetButtonDown(Crouch))
        {
            crouch(true);
        }

        if (Input.GetButtonDown(Jump))
        {
            jump();
        }



        if (Input.GetButtonUp(Crouch))
        {
            crouch(false);
        }
    }

    void moving()
    {
        if (!playerState.isCrouched)
        {
            horizontalMove(true);
        }

    }

    public void horizontalMove(bool move)
    {
        if (move)
        {
            if (!playerState.isCrouched)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0) + Vector3.right * Input.GetAxisRaw(HorizontalMove) * moveSpeed;
                if (playerState.isLanded)
                {
                    this.GetComponent<Animator>().enabled = true;
                }

            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            this.GetComponent<Animator>().enabled = false;
            if (playerState.isLanded && !playerState.isCrouched)
            {
                this.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
            }

        }
    }

    public void jump()
    {
        if (playerState.isLanded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0) + Vector3.up * jumpForce;
            playerState.isLanded = false;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = this.jumpSprite;


        }
    }

    public void crouch(bool crouched)
    {
        if (playerState.isLanded)
        {

            playerState.isCrouched = crouched;
            if (crouched && playerState.isLanded)
            {
                this.GetComponent<SpriteRenderer>().sprite = this.crouchedSprite;
                this.GetComponent<Animator>().enabled = false;
                rb.velocity = new Vector3(0, 0, 0);

            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
            }
        }

    }

}
