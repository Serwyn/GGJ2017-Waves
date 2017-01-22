using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperScript : MonoBehaviour {

    public float fillUp;
    public float maxFill;

	// Use this for initialization
	void Start () {
        fillUp = 0;
        GetComponent<Image>().fillAmount = fillUp / maxFill;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setFill(int amount)
    {
        fillUp += amount;
        GetComponent<Image>().fillAmount = fillUp/maxFill;
        if(fillUp == maxFill)
        {
            //set super as true
        }
    }

}
