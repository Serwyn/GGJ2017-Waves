using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamages : MonoBehaviour
{

    PlayerState ps4;
    public float highWaveDamages;
    public float lowWaveDamages;
    public float superDamages;
    float hitTimer;

    // Use this for initialization
    void Start () {
        hitTimer = 0;
        ps4 = this.GetComponent<PlayerState>();

    }
    void Update()
    {
        if(Time.time-hitTimer > 0.3 && ps4.isHit)
        {
            ps4.isHit = false;
        }
    }
	

    void OnTriggerEnter(Collider col)
    {
        if (!ps4.sa.supering || ps4.sa.superingPlayer != gameObject)
        {
            if (col.gameObject.tag == "onde")
            {
                ps4.life -= highWaveDamages;
                pushBack();



            }
            else if (col.gameObject.tag == "LowWave")
            {
                ps4.life -= lowWaveDamages;
                pushBack();
            }

            else if (col.gameObject.tag == "SuperAtk")
            {
                ps4.life -= superDamages;
                pushBack();
            }
        }

    }

    void pushBack()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float rpos = this.gameObject.GetComponent<PlayerState>().rpos;
        if (rpos < 0)
        {
            rb.velocity = new Vector3(GetComponent<PlayerController>().moveSpeed, GetComponent<PlayerController>().jumpForce/4 , 0);
            ps4.isLanded = false;
        }
        else
        {
            rb.velocity = new Vector3(-GetComponent<PlayerController>().moveSpeed, GetComponent<PlayerController>().jumpForce/4, 0);
            ps4.isLanded = false;
        }
        ps4.isHit = true;
        hitTimer = Time.time;

    }

}
