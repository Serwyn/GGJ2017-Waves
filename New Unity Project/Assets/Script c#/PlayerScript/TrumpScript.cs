using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpScript : MonoBehaviour {

    public GameObject list;
    public List<AudioClip> trump;
    public int trumpNbr;

	// Use this for initialization
	void Start () {
        trumpNbr = 0;
        trump = list.GetComponent<soundList>().trump;
	}
	
    public AudioClip getTrumpSound()
    {
        AudioClip sound = trump[trumpNbr % trump.Count];
        return sound;
    }


}
