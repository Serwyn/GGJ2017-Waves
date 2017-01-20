using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public GameObject onde;
    public GameObject shield;

    public string HighAttack;
    public string Shield;

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
        if (Input.GetButtonDown(Shield))
        {
            shieldSpawn();
        }
    }

    void highAttack()
    {
        GameObject attack = Instantiate(onde, new Vector3(transform.position.x, transform.position.y, (transform.position.z+1)%2), Quaternion.identity);
        Rigidbody aRB = attack.GetComponent<Rigidbody>();

        float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
        if (rpos < 0)
        {
            attack.transform.localEulerAngles = Vector3.up * 180;
        }
        aRB.velocity = Vector3.right * highWaveSpeed * Mathf.Sign(rpos);
    }

    void shieldSpawn()
    {
        GameObject instanciatedShield = Instantiate(shield, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Rigidbody aRB = shield.GetComponent<Rigidbody>();

        float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
        if (rpos < 0)
        {
            shield.transform.localEulerAngles = Vector3.up * 180;
        }
        aRB.velocity = Vector3.right * highWaveSpeed * Mathf.Sign(rpos);
    }




}
