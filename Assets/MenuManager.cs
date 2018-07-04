using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject[] Panels;

	// Use this for initialization
	void Start () {
        Constant.missionNum = 0;
        resetPanels();
        Panels[0].SetActive(true);
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
        resetPanels();
        Panels[i].SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
