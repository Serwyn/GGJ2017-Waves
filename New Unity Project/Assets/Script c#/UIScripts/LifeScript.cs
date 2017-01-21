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

        Image im1 = lb1.GetComponent<Image>();
        Image im2 = lb2.GetComponent<Image>();

        im1.fillAmount = life1 / MAXLIFE; //On change le remplissage
        im2.fillAmount = life2 / MAXLIFE;


        //On change la couleur
        Color couleur1 = new Color(1 - life1 / MAXLIFE, life1 / MAXLIFE, 0, 1);
        im1.color = couleur1;
  
        Color couleur2 = new Color(1 - life2 / MAXLIFE, life2 / MAXLIFE, 0, 1);
        im2.color = couleur2;



    }
}
