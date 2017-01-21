using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamages : MonoBehaviour
{

    PlayerState ps4;
    public float highWaveDamages;

	// Use this for initialization
	void Start () {
        ps4 = this.GetComponent<PlayerState>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "onde")
        {
            ps4.life -= highWaveDamages;
        }

    }

}
