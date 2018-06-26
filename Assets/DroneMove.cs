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
    float movingTime = 1.0f;
    private Vector3 startingPos;
    private Quaternion startingRot;
    // Use this for initialization
    void Start()
    {
        startingPos = transform.localPosition;
        startingRot = transform.localRotation;
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
                controlDrone(Constant.selectedCardIds[i]);
                yield return new WaitForSeconds(1.2f);
            }
        }
        if (Manager.mgr.missionNum == 0)
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
        switch (cardId)
        {
            case 0:
                iTween.MoveBy(gameObject, iTween.Hash("y", 4, "time", movingTime));
                break;
            case 1:
                iTween.MoveBy(gameObject, iTween.Hash("y", -4, "time", movingTime));
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
            case 5:
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
            Manager.mgr.reset();

        if (other.tag == "goal")
            Manager.mgr.checkMission();
    }
}
