using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour {

    public GameObject world;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restart()
    {

    }
    public void exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
