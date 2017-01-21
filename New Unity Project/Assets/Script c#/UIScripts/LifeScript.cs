using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour {
    
    //player 1 and 2
    public GameObject p1;
    public GameObject p2;

    //lifebar 1 and 2
    public GameObject lb1;
    public GameObject lb2;
    float MAXLIFE;

    void Start()
    {
        MAXLIFE = PlayerState.MAXLIFE;
    }
	
	// Update is called once per frame
	void Update () {

        UpdateLifeBar();
    

    

    }


    //unfill the life bar when the life go down.
    void UpdateLifeBar()
    {
        float life1 = p1.GetComponent<PlayerState>().life;
        float life2 = p2.GetComponent<PlayerState>().life;

        lb1.GetComponent<Image>().fillAmount = life1 / MAXLIFE;
        lb2.GetComponent<Image>().fillAmount = life2 / MAXLIFE;


    }
}
