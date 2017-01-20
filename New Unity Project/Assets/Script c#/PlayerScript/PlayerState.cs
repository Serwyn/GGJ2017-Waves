using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public bool isLanded;
    public bool hasJump;
    public bool isOnWall;
    public float life;

	// Use this for initialization
	void Start () {
        life = 100f;
        isLanded = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = true;
        }
    }
}
