using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject[] Panels;
    public int currentPanel;

	// Use this for initialization
	void Start () {
        Constant.missionNum = 0;
        resetPanels();
        switch (Constant.previousScene) {
            case Constant.SCENE_GAME:
                currentPanel = 1;
                Panels[1].SetActive(true);
                break;
            case Constant.SCENE_STUDY:
                currentPanel = 2;
                Panels[2].SetActive(true);
                break;
            default:
                currentPanel = 0;
                Panels[0].SetActive(true);
                break;

        }
        
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void resetPanels()
    {
        foreach (GameObject i in Panels) {
            i.SetActive(false);
        }
    }

    public void activatePanel(int i) {
        currentPanel = i;
        resetPanels();
        Panels[i].SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
