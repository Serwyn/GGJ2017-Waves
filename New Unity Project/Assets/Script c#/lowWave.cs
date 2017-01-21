using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowWave : MonoBehaviour {

    // Use this for initialization
    public float lifespan;
    void Start()
    {
        Destroy(this.gameObject, lifespan);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }

    }
}
