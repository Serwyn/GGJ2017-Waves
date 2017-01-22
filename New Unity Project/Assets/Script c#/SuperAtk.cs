using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAtk : MonoBehaviour {

    public float lifespan;

    void Start()
    {
        Destroy(this.gameObject, lifespan);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
