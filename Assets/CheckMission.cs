using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMission : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Manager.isPlaying)
        {
            if (other.tag == "box")
            {
                switch (Constant.missionNum)
                {
                    case 6:
                        Manager.mgr.checkMission();
                        break;
                    case 7:
                        if (Constant.currentCardId == 1)
                        {
                            Constant.isClearSubMission = true;
                            Constant.isGetBox = false;
                            Destroy(GameObject.FindGameObjectWithTag("box"));
                        }
                        else
                        {
                            Manager.mgr.goalFail();
                        }
                        break;
                    case 8:
                        Manager.mgr.checkMission();
                        break;
                    case 9:
                        Manager.mgr.checkMission();
                        break;
                }
            }

            if (other.tag == "water")
            {
                    Constant.isClearSubMission = true;
                GameObject.Find("DronePatrol").SendMessage("setBelowHouse", this.gameObject);
            }

            if (other.tag == "fireext")
            {
                other.transform.SetParent(gameObject.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "water")
        {
            Constant.isClearSubMission = false;
        }
    }
}
