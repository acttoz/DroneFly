using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStudy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void selectStudy(int i)
    {
        Constant.studyNum = i;
        SceneManager.LoadScene(4);
        GetComponent<AudioSource>().Play();
    }
}
