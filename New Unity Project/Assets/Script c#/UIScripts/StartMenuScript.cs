using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject selectorPanel;

	// Use this for initialization
	void Start () {
		
	}
	


    public void StartButton()
    {
        mainPanel.SetActive(false) ;
        selectorPanel.SetActive(true);

    }
    public void Credit()
    {
        Application.Quit();
    }

    public void LounchGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GetComponent<SelectScene>().getSceneName());
    }

}
