using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamages : MonoBehaviour
{

    PlayerState ps4;
    public float highWaveDamages;
    public float lowWaveDamages;

    // Use this for initialization
    void Start () {
        ps4 = this.GetComponent<PlayerState>();

    }
	

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "onde")
        {
            ps4.life -= highWaveDamages;
        }
        else if (col.gameObject.tag == "LowWave")
        {
            ps4.life -= lowWaveDamages;
        }

    }

}
