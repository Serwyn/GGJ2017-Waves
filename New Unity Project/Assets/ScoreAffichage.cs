using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreAffichage : MonoBehaviour {

    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;

    public GameObject imGauche;
    public GameObject imDroite;

    public int score1;
    public int score2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Image imG = imGauche.GetComponent<Image>();
        Image imD = imDroite.GetComponent<Image>();

       if(score1 == 0)
        {
            imG.sprite = sprite0;
        }
       else if(score1 == 1)
        {
            imG.sprite = sprite1;
        }
       else
        {
            imG.sprite = sprite2;
        }

        if (score2 == 0)
        {
            imD.sprite = sprite0;
        }
        else if (score2 == 1)
        {
            imD.sprite = sprite1;
        }
        else
        { 
            imD.sprite = sprite2;
        }

    }
}
