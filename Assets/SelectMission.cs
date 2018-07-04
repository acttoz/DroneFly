using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMission : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void goToMission(int mission)
    {
        Constant.missionNum = mission;
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        GetComponent<AudioSource>().Play();
    }
}
