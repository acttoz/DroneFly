using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backBtn : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (Constant.currentSceneId)
            {
                case 0:
                    if (GameObject.Find("Canvas").GetComponent<MenuManager>().currentPanel == 0)
                        Application.Quit();
                    else
                        GameObject.Find("Canvas").GetComponent<MenuManager>().activatePanel(0);
                    break;
                case 1:
                    SceneManager.LoadScene(0);
                    break;
                case 2:
                    SceneManager.LoadScene(0);
                    break;
                case 3:
                    if (Constant.previousScene == Constant.SCENE_GAME)
                        SceneManager.LoadScene(0);
                    if (Constant.previousScene == Constant.SCENE_STAGE)
                        SceneManager.LoadScene(2);
                    break;
                case 4:
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}
