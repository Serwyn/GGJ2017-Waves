using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	// Use this for initialization
    public float lifespan;
	void Start () {
        Destroy(this.gameObject, lifespan);
		
	}
	

}
