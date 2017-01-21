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
    public float endManche1Pause;
    public float endManche2Pause;

    float timePause = 0;
    bool isPaused1;
    bool isPaused2;
    bool isPaused3;
   

    // Use this for initialization
    void Start () {
        isPaused1 = false;
        isPaused2 = false;
        isPaused3 = false;
        player1State = player1.GetComponent<PlayerState>();
        player2State = player2.GetComponent<PlayerState>();
        restartWorld();
	}

	public bool isPaused()
    {
        return isPaused1 || isPaused2 || isPaused3;
    }

	// Update is called once per frame
	void Update () {
        if (!isPaused())
        {
            if (player1State.life <= 0)
            {
                //start death animation
                player2win();
            }
            if (player2State.life <= 0)
            {
                //start death animation
                player1win();
            }
        }
        else {
            if (isPaused1 && Time.realtimeSinceStartup - timePause > endManche1Pause)
            {
                endManche();
            }

            if (isPaused2 && Time.realtimeSinceStartup - timePause > endManche2Pause)
            {
                isPaused2 = false;
            }
        }

    }

    void player2win()
    {
        player2Winshare += 1;
        player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<PlayerController>().deadSprite;
        player1.GetComponent<Animator>().enabled = false;

        player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<PlayerController>().normalSprite;
        player2.GetComponent<Animator>().enabled = false;

        endManche();

    }
    void player1win()
    {
        player1Winshare += 1;
        player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<PlayerController>().deadSprite;
        player2.GetComponent<Animator>().enabled = false;

        player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<PlayerController>().normalSprite;
        player1.GetComponent<Animator>().enabled = false;
        endManche();
    }

    void endManche()
    {


        totalWin = Mathf.Max(player1Winshare, player2Winshare);
        if (totalWin == maxWin)
        {
            endGame();
            return;
        }

        if (isPaused1 == false)
        {
            timePause = Time.time;
            isPaused1 = true;
            return;
        }
        isPaused1 = false;
        player1State.reset();
        player2State.reset();
        
        timePause = Time.time;
        isPaused2 = true;

    }
    void endGame()
    {
        timePause = Time.time;
        isPaused3 = true;

        panel.SetActive(true);
    }
    public void restartWorld()
    {
        panel.SetActive(false);
        isPaused3 = false;
        isPaused2 = false;
        isPaused1 = false;
        totalWin = 0;
        player1Winshare = 0;
        player2Winshare = 0;
        player1State.reset();
        player2State.reset();
    }


}
