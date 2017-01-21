using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public bool isLanded;
    public bool hasJump;
    public bool isOnWall;
    public const float MAXLIFE=100f;
    public float life;
    public float rpos;

	// Use this for initialization
	void Start () {
        life = MAXLIFE;
        isLanded = false;
	}
	
	// Update is called once per frame
	void Update () {
        relativePosition();
	}

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = true;
        }
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = false;
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
