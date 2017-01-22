using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public bool isLanded;
    public bool isHit;
    public bool hasJump;
    public bool isOnWall;
    public bool isCastingHigh;
    public bool isCastingLow;
    public bool isCrouched;
    public int supering;
    public const float MAXLIFE=100;
    public float life;
    public float MAXMANA;
    public float mana;
    public float rpos;
    public Vector3 initPosition;
    public superAttack sa;

    worldController wc;

    // Use this for initialization
    void Start () {
        wc = Camera.main.GetComponent<worldController>();
        sa = Camera.main.GetComponent<superAttack>();
        reset();
    }

    public void reset()
    {
        life = MAXLIFE;
        isLanded = true;
        isCrouched = false;
        hasJump = false;
        isHit = false;
        this.transform.position = initPosition;
        GetComponent<SpriteRenderer>().sprite = GetComponent<PlayerController>().normalSprite;
        GetComponent<Animator>().enabled = false;
        relativePosition();

    }
	
	// Update is called once per frame
	void Update () {
        if (!wc.isPaused())
        {
            relativePosition();
        }
	}


    void relativePosition()
    {
        rpos = gameObject.GetComponent<PlayerController>().otherPlayer.transform.position.x- this.transform.position.x;
        if (rpos > 0)
        {
            transform.localEulerAngles = Vector3.up*180;
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
