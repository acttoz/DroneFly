using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject[] slots;
    public static GameObject o;
	// Use this for initialization
	void Start () {
        o = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetSlots() {
        foreach (GameObject slot in slots) {
            slot.GetComponent<Slot>().reMoveCard();
        }
    }
}
