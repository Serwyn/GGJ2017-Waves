using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarScript : MonoBehaviour {

    public GameObject list;
    public List<AudioClip> guit;
    public int guitNbr;

	// Use this for initialization
	void Start () {
        guitNbr = 0;
        guit = list.GetComponent<soundList>().rock;
	}
	
    public AudioClip getGuitSound()
    {
        AudioClip sound = guit[guitNbr % guit.Count];
        return sound;
    }


}
