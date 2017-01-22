using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SuperScript : MonoBehaviour {
    public GameObject player;
    PlayerState ps;
    float fillUp;
    float maxFill;

	// Use this for initialization
	void Start () {
        ps = player.GetComponent<PlayerState>();
        maxFill = ps.MAXMANA;
        GetComponent<Image>().fillAmount = ps.mana / maxFill;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().fillAmount = ps.mana / maxFill;
    }

    public void setFill(int amount)
    {
        ps.mana += amount;
    }

}
