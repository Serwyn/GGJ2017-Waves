using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public bool isLanded;
    public bool hasJump;
    public bool isOnWall;
    public float life;
    public float rpos;

	// Use this for initialization
	void Start () {
        life = 100f;
        isLanded = false;
	}
	
	// Update is called once per frame
	void Update () {
        relativePosition();
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = true;
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
