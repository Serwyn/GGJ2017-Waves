using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highWave : MonoBehaviour {

	// Use this for initialization
    public float lifespan;
	void Start () {
        Destroy(this.gameObject, lifespan);
		
	}
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }

    }
    public void PlayAudioSource(AudioClip audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
    }
}
