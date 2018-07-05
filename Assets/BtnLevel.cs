using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum PreviousLevel:int
{

    stage=0,study=1,game=2

}


public class BtnLevel : MonoBehaviour
{
    public PreviousLevel Pv;
    public int levelNum;
    Button btn;
    public int previousNum;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClik);
	}
    

    private void onClik()
    {
        Constant.previousScene = (int)Pv;
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(levelNum);
    }

    // Update is called once per frame
    void Update () {
	}


}
