using System;
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
    GameObject objBox;
    GameObject objFireExt;
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
