﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highWave : MonoBehaviour {

	// Use this for initialization
    private float lifespan = 4.0f;
	void Start () {
        Destroy(this, lifespan);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("collision");

        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
