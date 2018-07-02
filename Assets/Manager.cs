﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject drone;
    public GameObject playBtn;
    public GameObject goalText;
    public GameObject resultGoalText;
    public GameObject resultGoalPanel;
    public GameObject objBox;
    public GameObject objFireExt;
    public static GameObject o;
    public static Manager mgr;
    public Color currentSlotColor;
    public static bool isPlaying = false;


    public GameObject[] slots;
    public GameObject[] missionMaps;
    // Use this for initialization
    void Start()
    {

        int defaultValue = EventSystem.current.pixelDragThreshold;
        EventSystem.current.pixelDragThreshold =
                Mathf.Max(
                     defaultValue,
                     (int)(defaultValue * Screen.dpi / 160f));
        resetMission();
        o = this.gameObject;
        mgr = GetComponent<Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene(0); }
    }
    public void resetMission()
    {
        Constant.selectedCardIds.Clear();
        Constant.repeatList.Clear();
        Constant.currentSlotId = 0;
        resetSlots();
        reset();
    }

    public void resetSlots()
    {

        foreach (GameObject slot in slots)
        {
            slot.GetComponent<Slot>().reMoveCard();
            slot.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    public void currentSlot(int index)
    {
        foreach (GameObject slot in slots)
        {
            slot.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        slots[index].GetComponent<Image>().color = currentSlotColor;
    }

    public void play()
    {
        Manager.isPlaying = true;
        playBtn.GetComponent<PlayBtn>().setResetBtn();
        drone.SendMessage("play");
    }
    public void reset()
    {
        Constant.isClearSubMission = false;
        Constant.isGetBox = false;
        Constant.isGetFireExt = false;
        Constant.height = 0;
        Constant.isFlying = false;
        foreach (GameObject slot in slots)
        {
            slot.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        foreach (GameObject missionMap in missionMaps)
        {
            try { missionMap.SetActive(false); } catch (Exception E) { }
        }


        resultGoalPanel.SetActive(false);


        missionMaps[Constant.missionNum].SetActive(true);
        if (Constant.missionNum < 5)
        {

        }
        else if (Constant.missionNum > 4 && Constant.missionNum < 10)
        {
            Destroy(GameObject.FindGameObjectWithTag("box"));
            GameObject tempobj = Instantiate(objBox, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(-90, 0, -9)), GameObject.Find("BoxPosition").transform) as GameObject;
            tempobj.transform.localPosition = new Vector3(0, 0, 0);
            tempobj.transform.localRotation = Quaternion.Euler(-90, 0, -9);
            //GameObject.FindGameObjectWithTag("box").transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
        }

        goalText.GetComponent<Text>().text = Constant.goals[Constant.missionNum];
        resultGoalText.GetComponent<Text>().text = Constant.goals[Constant.missionNum];
        Manager.isPlaying = false;
        playBtn.GetComponent<PlayBtn>().setPlayBtn();
        //Constant.selectedCardIds.Clear();
        drone.SendMessage("resetDrone");

    }

    public void checkMission()
    {
        switch (Constant.missionNum)
        {
            case 0:
                if (Constant.selectedCardIds.Contains(Constant.cardUp))
                    if (!Constant.isFlying)
                        goalSuccess();
                    else
                        goalFail();
                break;
            case 5:
                if (Constant.currentCardId == 1)
                    goalSuccess();
                else
                    goalFail();
                break;
            case 6:
                if (Constant.currentCardId == 1)
                {
                    if (Constant.isGetBox)
                        goalSuccess();
                }
                else
                {
                    goalFail();
                }
                break;
            case 7:
                if (Constant.isClearSubMission)
                    goalSuccess();
                break;

            default:
                goalSuccess();
                break;
        }
    }

    public void goalFail()
    {
        reset();
    }

    private void goalSuccess()
    {
        isPlaying = false;
        resultGoalPanel.SetActive(true);
    }


}
