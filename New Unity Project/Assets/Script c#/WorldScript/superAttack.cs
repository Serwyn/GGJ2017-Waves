using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superAttack : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public bool supering;
    public GameObject superingPlayer;
    public float superingStart;
    public float superingDuration;

	// Use this for initialization
	void Start () {
        supering = false;
        superingStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - superingStart > superingDuration && supering)
        {
            supering = false;
        }
		
	}
}
