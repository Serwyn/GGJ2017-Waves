using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScene : MonoBehaviour {

    public GameObject scenePrewiev;
    public List<string> sceneName;
    public List<Sprite> preview;
    public int sceneNbr;

	// Use this for initialization
	void Start () {
        sceneNbr = 0;
	}
	
    public void leftArrow()
    {
        if (sceneNbr == 0)
        {
            sceneNbr = preview.Count+1;
        }
        else
        {
            sceneNbr -= 1;
        }
        updateScene();
    }
    public void rightArrow()
    {
        sceneNbr += 1;
        updateScene();
    }

    public void updateScene()
    {
        scenePrewiev.GetComponent<Image>().sprite = preview[sceneNbr % preview.Count];
    }

    public string getSceneName()
    {
        string name = sceneName[sceneNbr % sceneName.Count];
        return name;
    }
	// Update is called once per frame
	
}
