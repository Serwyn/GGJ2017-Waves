using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public GameObject onde;
    public string HighAttack;
    public float highWaveSpeed = 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(HighAttack))
        {
            highAttack();
        }
    }

    void highAttack()
    {
        GameObject attack = Instantiate(onde, new Vector3(transform.position.x, transform.position.y, (transform.position.z+1)%2), Quaternion.identity);
        Rigidbody aRB = attack.GetComponent<Rigidbody>();
        aRB.velocity = new Vector3(highWaveSpeed, 0, 0);
    }




}
