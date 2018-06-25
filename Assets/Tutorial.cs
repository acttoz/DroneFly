using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public GameObject obj1, obj2, obj3, obj4;
    public GameObject drone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void tutorial(int order) {
        switch (order) {
            case 0:
                Debug.Log("tutorial1");
                obj1.SetActive(false);
                obj2.SetActive(true);
                GameObject.Find("Slot").GetComponentInChildren<Text>().text = "전진";
                GameObject.Find("BtnCard").SetActive(false);
                Constant.selectedCardIds.Add(2);
                break;
            case 1:
                drone.SendMessage("moveTutorial");
                obj2.SetActive(false);

                break;
            case 2:
                Debug.Log("success");
                break;
        }
    }

}
