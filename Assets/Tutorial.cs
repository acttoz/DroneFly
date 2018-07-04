using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject obj1, obj2;
    public GameObject drone;
    public GameObject resultTutorial;
    int i = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void tutorial(int order)
    {
        GetComponent<AudioSource>().Play();

        switch (order)
        {
            case 0:
                i++;
                switch (i)
                {
                    case 1:
                        Constant.selectedCardIds.Add(0);
                        Constant.currentSlotId++;
                        break;
                    case 2:
                        Constant.selectedCardIds.Add(0);
                        Constant.currentSlotId++;
                        obj1.SetActive(false);
                        obj2.SetActive(true);
                        GameObject.Find("BtnCard").SetActive(false);
                        break;
                }
                break;
            case 1:
                drone.SendMessage("moveTutorial");
                obj2.SetActive(false);

                break;
            case 2:
                resultTutorial.SetActive(true);
                break;
        }
    }

}
