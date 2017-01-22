using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private float lastCast;

    public float lowDelay;
    private float lastLow;

    private PlayerState ps;
    Rigidbody rb;


    worldController wc;

    // Use this for initialization
    void Start () {
        wc = Camera.main.GetComponent<worldController>();
        rb = GetComponent<Rigidbody>();
        ps = this.GetComponent<PlayerState>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!wc.isPaused())
        {
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
                ps.isCastingHigh = false;
            }
            if (Time.time - this.lastLow > this.lowDelay)
            {
                ps.isCastingLow = false;
            }
        }
    }

    void highAttack()
    {
        if (!ps.isCastingHigh && !ps.isCrouched && !ps.isHit && !ps.sa.supering)
        {
            ps.isCastingHigh = true;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            this.lastCast = Time.time;
            GameObject attack = Instantiate(onde, new Vector3(ondeLocation.transform.position.x, ondeLocation.transform.position.y, ((int)(transform.position.z + 0.5) + 1) % 2), Quaternion.identity);
            try
            {
                AudioClip audio = GetComponent<TrumpScript>().getTrumpSound();
                AudioSource.PlayClipAtPoint(audio, Vector3.zero, 0.7f);

            }
            catch { }
            try
            {
                AudioClip audio = GetComponent<GuitarScript>().getGuitSound();
                AudioSource.PlayClipAtPoint(audio, Vector3.zero, 1f);

            }
            catch { }
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
        if (!ps.isCastingLow && !ps.isCrouched && !ps.isHit && !ps.sa.supering)
        {
            ps.isCastingLow = true;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            this.lastLow = Time.time;
            GameObject attack = Instantiate(lowWave, new Vector3(lowWaveLocation.transform.position.x, lowWaveLocation.transform.position.y, ((int)(transform.position.z+0.5) + 1) % 2), Quaternion.identity);
            try
            {
                AudioClip audio = GetComponent<TrumpScript>().getTrumpSound();
                AudioSource.PlayClipAtPoint(audio, Vector3.zero, 0.7f);

            }
            catch { }
            try
            {
                AudioClip audio = GetComponent<GuitarScript>().getGuitSound();
                AudioSource.PlayClipAtPoint(audio, Vector3.zero, 1f);

            }
            catch { }
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
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
            if (Time.time - shieldTime > shieldTimer && !ps.isCrouched && !ps.isHit && !ps.sa.supering)
            {
                shieldTime = Time.time;
                GameObject instanciatedShield = Instantiate(shield, new Vector3(shieldLocation.transform.position.x, shieldLocation.transform.position.y, (int)(transform.position.z + 0.5)), Quaternion.identity);
                try
                {
                AudioClip audio = GetComponent<TrumpScript>().getTrumpSound();
                AudioSource.PlayClipAtPoint(audio, Vector3.zero, 0.7f);

                }
                catch { }
                try
                {
                AudioClip audio = GetComponent<GuitarScript>().getGuitSound();
                AudioSource.PlayClipAtPoint(audio,Vector3.zero, 1f);

                }
                catch { }
                Rigidbody aRB = shield.GetComponent<Rigidbody>();
                float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
                if (rpos < 0)
                {
                    shield.transform.localEulerAngles = Vector3.up * 180;
                }
            }
    }




}
