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
    public Sprite deadSprite;

    public GameObject lueure;

    public string HorizontalMove;
    public string Jump;
    public string Crouch;
    public string Super;
    worldController wc;
    

   

    // Use this for initialization
    void Start () {
        wc = Camera.main.GetComponent<worldController>();
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!wc.isPaused())
        {
            if (!playerState.sa.supering || playerState.sa.superingPlayer != gameObject)
            {
                if (!playerState.isHit)
                {
                    if (!playerState.sa.supering && playerState.isLanded && !playerState.isCrouched && Input.GetButtonDown(Super) && playerState.mana>=playerState.MAXMANA)
                    {
                        playerState.mana = 0;
                        playerState.sa.supering = true;
                        playerState.sa.superingStart = Time.time;
                        playerState.sa.superingPlayer = gameObject;

                        rb.velocity = Vector3.zero;
                        this.GetComponent<SpriteRenderer>().sprite = this.crouchedSprite;
                        this.GetComponent<Animator>().enabled = false;
                        lueure.transform.position = new Vector3(transform.position.x, lueure.transform.position.y, lueure.transform.position.z);
                        lueure.GetComponent<SpriteRenderer>().enabled = true;

                    }


                    else
                    {
                        if (Input.GetButton(HorizontalMove))
                        {
                            horizontalMove(true);
                        }
                        else if (playerState.isLanded && !playerState.isCrouched)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
                            horizontalMove(false);
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
                }
            }
            else//sa.supering
            {
                if (playerState.sa.superingPlayer != gameObject)
                {

                }
            }
        }
        else if (playerState.isLanded)
        {
            rb.velocity = Vector3.zero;
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
        if (playerState.isLanded && ! playerState.isCrouched)
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


            if (crouched && !playerState.isCrouched)
            {
                BoxCollider boxco = this.GetComponent<BoxCollider>();
                float size = boxco.size.y;
                boxco.size = new Vector3(boxco.size.x, boxco.size.y / 2, boxco.size.z);
                boxco.center = new Vector3(boxco.center.x, boxco.center.y - size / 4, boxco.center.z);

                this.GetComponent<SpriteRenderer>().sprite = this.crouchedSprite;
                this.GetComponent<Animator>().enabled = false;
                rb.velocity = new Vector3(0, 0, 0);

            }
            else if(playerState.isCrouched)
            {
                BoxCollider boxco = this.GetComponent<BoxCollider>();
                float size = boxco.size.y;
                boxco.size = new Vector3(boxco.size.x, boxco.size.y * 2, boxco.size.z);
                boxco.center = new Vector3(boxco.center.x, boxco.center.y + size/2, boxco.center.z);

                this.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
            }
            playerState.isCrouched = crouched;
        }

    }

}
