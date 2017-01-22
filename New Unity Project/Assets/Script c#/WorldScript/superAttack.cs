using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superAttack : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject baliseG;
    public GameObject baliseD;
    public bool supering;
    public GameObject superingPlayer;
    public float superingStart;
    public float superingDuration;
    public int nbCroches;
    public int crocheSpeed;
    int doneCroches;
    public GameObject Croche;
    public GameObject lueure;
   

    // Use this for initialization
    void Start () {
        doneCroches = 0;
        supering = false;
        superingStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (supering)
        {
            if (Time.time - superingStart > superingDuration)
            {
                supering = false;
                doneCroches = 0;
                lueure.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (Time.time - superingStart > doneCroches * superingDuration / (float)nbCroches)
            {
                doneCroches += 1;
                Vector3 position = baliseG.transform.position + Random.value*(baliseD.transform.position-baliseG.transform.position);
                Debug.Log(position);
                GameObject croche = Instantiate(Croche, new Vector3(position.x, position.y, ((int)(superingPlayer.transform.position.z + 0.5) + 1) % 2), Quaternion.identity);
                croche.GetComponent<Rigidbody>().velocity = new Vector3(0, -crocheSpeed*Random.Range(0.8f, 1), 0);
            }
        }


        }
    }
