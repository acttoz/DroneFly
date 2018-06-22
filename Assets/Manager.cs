using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject drone;
    public GameObject playBtn;
    public GameObject goalText;
    public static GameObject o;
    public static Manager mgr;
    public Color currentSlotColor;
    public static bool isPlaying = false;
    public int missionNum;
    public GameObject[] slots;
    // Use this for initialization
    void Start()
    {
        reset();
        o = this.gameObject;
        mgr = GetComponent<Manager>();

    }

    // Update is called once per frame
    void Update()
    {

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
        goalText.GetComponent<Text>().text = Constant.goals[missionNum];
        Manager.isPlaying = false;
        playBtn.GetComponent<PlayBtn>().setPlayBtn();
        Constant.selectedCardIds.Clear();
        resetSlots();
        drone.SendMessage("resetDrone");
    }

    public void checkMission()
    {
        switch (missionNum)
        {
            case 0:
                if (Constant.selectedCardIds.Contains(Constant.cardUp))
                    if (Constant.selectedCardIds.Contains(Constant.cardDown))
                        goalSuccess();
                    else
                        goalFail();
                break;
        }
    }

    private void goalFail()
    {
        Debug.Log("fail");

    }

    private void goalSuccess()
    {
        Debug.Log("success");
    }
}
