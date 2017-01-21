using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public GameObject onde;
    public GameObject lowWave;
    public GameObject shield;

    public GameObject ondeLocation;
    public GameObject shieldLocation;
    public GameObject lowWaveLocation;

    public string HighAttack;
    public string LowAttack;
    public string Shield;

    public float highWaveSpeed;
    public float lowWaveSpeed;
    public float shieldTimer;
    private float shieldTime;
    public float blockingDelay;

    private PlayerState ps;
    private float lastCast;
    
	// Use this for initialization
	void Start () {
        ps = this.GetComponent<PlayerState>();


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(HighAttack))
        {
            highAttack();
        }

        if (Input.GetButtonDown(LowAttack))
        {
            lowAttack();
        }

        if (Input.GetButtonDown(Shield))
        {
            shieldSpawn();
        }
        if (Time.time - this.lastCast > this.blockingDelay)
        {
            ps.isCasting = false;
        }
    }

    void highAttack()
    {
        if (!ps.isCasting && !ps.isCrouched)
        {
            ps.isCasting = true;
            this.lastCast = Time.time;
            GameObject attack = Instantiate(onde, new Vector3(ondeLocation.transform.position.x, ondeLocation.transform.position.y, (transform.position.z + 1) % 2), Quaternion.identity);
            Rigidbody aRB = attack.GetComponent<Rigidbody>();

            float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
            if (rpos < 0)
            {
                attack.transform.localEulerAngles = Vector3.up * 180;
            }
            aRB.velocity = Vector3.right * highWaveSpeed * Mathf.Sign(rpos);
        }
    }

    void lowAttack()
    {
        if (!ps.isCasting && !ps.isCrouched)
        {
            ps.isCasting = true;
            this.lastCast = Time.time;
            GameObject attack = Instantiate(lowWave, new Vector3(lowWaveLocation.transform.position.x, lowWaveLocation.transform.position.y, (transform.position.z + 1) % 2), Quaternion.identity);
            Rigidbody aRB = attack.GetComponent<Rigidbody>();

            float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
            if (rpos < 0)
            {
                attack.transform.localEulerAngles = Vector3.up * 180;
            }
            aRB.velocity = Vector3.right * lowWaveSpeed * Mathf.Sign(rpos);
        }
    }

    void shieldSpawn()
    {
        if (!ps.isCasting)
        {
            ps.isCasting = true;
            this.lastCast = Time.time;
            if (Time.time - shieldTime > shieldTimer)
            {
                shieldTime = Time.time;
                GameObject instanciatedShield = Instantiate(shield, new Vector3(shieldLocation.transform.position.x, shieldLocation.transform.position.y, transform.position.z), Quaternion.identity);
                Rigidbody aRB = shield.GetComponent<Rigidbody>();
                float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
                if (rpos < 0)
                {
                    shield.transform.localEulerAngles = Vector3.up * 180;
                }
            }
        }
    }




}
