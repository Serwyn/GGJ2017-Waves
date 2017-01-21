using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour {

    public GameObject world;

    public worldController controlWorld;

	// Use this for initialization
	void Start () {
        controlWorld = world.GetComponent<worldController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restart()
    {
        controlWorld.restartWorld();
    }
    public void exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
        
    }
}
