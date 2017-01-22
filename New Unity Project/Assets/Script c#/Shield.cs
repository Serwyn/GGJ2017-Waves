using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour {

    public GameObject super1;
    public GameObject super2;

    public GameObject player1;
    public GameObject player2;

	// Use this for initialization
    public float lifespan;
	void Start () {
        super1 = GameObject.FindGameObjectWithTag("Super1");
        super2 = GameObject.FindGameObjectWithTag("Super2");
        Destroy(this.gameObject, lifespan);
		
	}
    public void PlayAudioSource(AudioClip audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "Player")
        {
            if (transform.position.z == 1)
            {
                super1.GetComponent<SuperScript>().setFill(1);

            }
            else
            {
                super2.GetComponent<SuperScript>().setFill(1);
            }
        }
    }
}
