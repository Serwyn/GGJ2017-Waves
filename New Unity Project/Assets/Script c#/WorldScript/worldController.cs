using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldController : MonoBehaviour {

    public GameObject panel;

    public GameObject player1;
    public GameObject player2;

    PlayerState player1State;
    PlayerState player2State;

    public int player1Winshare;
    public int player2Winshare;
    public int totalWin;
    public int maxWin;

	// Use this for initialization
	void Start () {
        player1State = player1.GetComponent<PlayerState>();
        player2State = player2.GetComponent<PlayerState>();
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(player1State.life <= 0)
        {
            //start death animation
            player2win();
        }
        if(player2State.life <= 0)
        {
            //start death animation
            player1win();
        }
	}

    void player2win()
    {
        player2Winshare += 1;
        endManche();

    }
    void player1win()
    {
        player1Winshare += 1;
        endManche();
    }

    void endManche()
    {
        totalWin = player1Winshare + player2Winshare;
        player1State.reset();
        player2State.reset();
        if(totalWin == maxWin)
        {
            endGame();
        }
    }
    void endGame()
    {
        panel.SetActive(true);
    }
}
