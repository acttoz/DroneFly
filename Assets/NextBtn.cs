using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void nextLevel() {
        Manager.mgr.missionNum+=1;
        Manager.mgr.resetSlots();
        Manager.mgr.reset();
    }

}
