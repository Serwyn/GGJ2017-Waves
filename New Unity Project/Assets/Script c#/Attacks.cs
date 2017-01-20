using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {
    public float velocity;

    public GameObject onde;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("HighAttack"))
        {
            highAttack();
        }
    }

    void highAttack()
    {
        GameObject attack = Instantiate(onde, transform.position, Quaternion.identity);
        Rigidbody2D aRB = attack.GetComponent<Rigidbody2D>();
        aRB.velocity = new Vector2(velocity, 0);
    }




}
