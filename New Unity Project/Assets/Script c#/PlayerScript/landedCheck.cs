using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landedCheck : MonoBehaviour {
    public PlayerState ps;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            ps.isLanded = true;
        }
    }
    void OnTrigerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            ps.isLanded = false;
        }
    }


}
