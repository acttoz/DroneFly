using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  cardUp=0;
//cardDown = 1;
//cardFoward = 2;
//cardLeft = 3;
//cardRight = 4;
//cardRepeat = 5;
/// </summary>

public class DroneMove : MonoBehaviour
{
    float movingTime = 0.2f;
    float waitTime;
    private Vector3 startingPos;
    private Quaternion startingRot;
    public GameObject belowHouse;
    // Use this for initialization
    void Start()
    {
        startingPos = transform.localPosition;
        startingRot = transform.localRotation;
        waitTime = movingTime + 0.1f;
    }
    public void play()
    {
        StartCoroutine(move());
    }

    public void resetDrone()
    {
        iTween.Stop();
        transform.localPosition = startingPos;
        transform.localRotation = startingRot;

    }

    // Update is called once per frame
    void Update()
    {

    }

    // every 2 seconds perform the print()
    private IEnumerator move()
    {
        for (int i = 0; i < Constant.selectedCardIds.Count; i++)
        {
            if (!Manager.isPlaying)
                break;
            Manager.mgr.currentSlot(i);
            for (int j = 0; j < Constant.repeatList[i]; j++)
            {
                if (!Manager.isPlaying)
                    break;

                if (Constant.selectedCardIds[i] == 6 && Constant.isGetWater)
                {
                    controlDrone(6);
                    yield return new WaitForSeconds(3);
                    Destroy(transform.GetChild(0).GetChild(0).gameObject);
                    Constant.isGetWater = false;
                    if (belowHouse != null)
                        belowHouse.transform.GetChild(0).gameObject.SetActive(false);
                    yield return new WaitForSeconds(1);
                    Manager.mgr.checkMission();
                    break;
                }
                controlDrone(Constant.selectedCardIds[i]);
                yield return new WaitForSeconds(waitTime);
            }
        }
        if (Constant.missionNum == 0)
            Manager.mgr.checkMission();
    }

    public void moveTutorial()
    {
        StartCoroutine(moveTu());
    }

    private IEnumerator moveTu()
    {
        for (int i = 0; i < Constant.selectedCardIds.Count; i++)
        {
            controlDrone(Constant.selectedCardIds[i]);
            yield return new WaitForSeconds(1.2f);
        }
        GameObject.Find("Canvas (1)").SendMessage("tutorial", 2);
    }

    private void controlDrone(int cardId)
    {
        Constant.currentCardId = cardId;
        if (!Constant.isFlying)
        {
            if (cardId == 0)
            {
                iTween.MoveBy(gameObject, iTween.Hash("y", 1.5, "time", movingTime));
                Constant.height = 1;
                Constant.isFlying = true;
            }
            else
                Manager.mgr.goalFail();
        }
        else
        {
            switch (cardId)
            {
                case 0:
                    Constant.height++;
                    if(Constant.height<4)
                    iTween.MoveBy(gameObject, iTween.Hash("y", 3, "time", movingTime));
                    break;
                case 1:
                    if (Constant.height == 1)
                    {
                        iTween.MoveBy(gameObject, iTween.Hash("y", -1.5, "time", movingTime));
                        Constant.isFlying = false;
                    }
                    else
                    {
                        iTween.MoveBy(gameObject, iTween.Hash("y", -3, "time", movingTime));
                    }
                    Constant.height--;
                    break;
                case 2:
                    iTween.MoveBy(gameObject, iTween.Hash("x", 4, "time", movingTime));
                    break;
                case 3:
                    iTween.RotateBy(gameObject, iTween.Hash("y", -0.25, "time", movingTime));
                    break;
                case 4:
                    iTween.RotateBy(gameObject, iTween.Hash("y", 0.25, "time", movingTime));
                    break;
                case 6:
                    transform.GetChild(0).GetChild(0).GetComponent<Animation>().Play();
                    break;


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Manager.isPlaying)
        {
            if (other.tag == "enemy") {
                Manager.mgr.goalFail();
                Debug.Log("fail");
            }

            if (other.tag == "goal")
            {
                Manager.mgr.checkMission();
            }

            if (other.tag == "goal_sub")
            {

            }

            if (other.tag == "box")
            {
                if (Constant.currentCardId != 1)
                {
                    Manager.mgr.goalFail();
                }
                else if (!Constant.isGetBox)
                {
                    Constant.isGetBox = true;
                    other.transform.SetParent(gameObject.transform.GetChild(0));
                    if (Constant.missionNum == 5)
                        Manager.mgr.checkMission();
                }
            }

            if (other.tag == "water")
            {
                if (Constant.currentCardId != 1)
                {
                    Manager.mgr.goalFail();
                }
                else if (!Constant.isGetWater)
                {
                    Constant.isGetWater = true;
                    other.transform.SetParent(gameObject.transform.GetChild(0));
                }
            }

            if (other.tag == "fireext")
            {
                other.transform.SetParent(gameObject.transform);
            }
        }
    }
    public void setBelowHouse(GameObject temp) {
        belowHouse = temp;
    }
}