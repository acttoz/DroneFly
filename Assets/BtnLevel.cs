using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BtnLevel : MonoBehaviour
{
    public int levelNum;
    Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClik);
	}

    private void onClik()
    {
        SceneManager.LoadScene(levelNum);
    }

    // Update is called once per frame
    void Update () {
		
	}


}
