using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

//The list of colliders currently inside the trigger
public class landedCheck : MonoBehaviour {
    public PlayerState ps;
    public int nbGrounds;

	// Use this for initialization
	void Start () {
        nbGrounds = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            ps.isLanded = true;
            nbGrounds += 1;
        }
    
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            nbGrounds -= 1;
            if (nbGrounds == 0)
            {
                ps.isLanded = false;
            }
            
        }
    }


}
