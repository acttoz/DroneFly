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
    public GameObject resultGoalText2;
    public GameObject resultGoalPanel;
    public GameObject failGoalPanel;
    public GameObject objBox;
    public GameObject objWater;
    public static GameObject o;
    public static Manager mgr;
    public Color currentSlotColor;
    public static bool isPlaying = false;
    public GameObject fire1, fire2;


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
        isPlaying = false;
        Constant.isClearSubMission = false;
        Constant.isClearSubMission2 = false;
        Constant.isGetBox = false;
        Constant.isGetWater = false;
        Constant.height = 0;
        Constant.isFlying = false;
        isPlaying = false;
        foreach (GameObject slot in slots)
        {
            slot.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        foreach (GameObject missionMap in missionMaps)
        {
            try { missionMap.SetActive(false); } catch (Exception E) { }
        }

        resultGoalPanel.SetActive(false);
        failGoalPanel.SetActive(false);

        missionMaps[Constant.missionNum].SetActive(true);
        if (Constant.missionNum < 5)
        {

        }
        else if (Constant.missionNum > 4 && Constant.missionNum < 10)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("box"))
            {
                Destroy(obj);
            }
            GameObject tempobj = Instantiate(objBox, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(-90, 0, -9)), GameObject.Find("BoxPosition").transform) as GameObject;
            tempobj.transform.localPosition = new Vector3(0, 0, 0);
            tempobj.transform.localRotation = Quaternion.Euler(-90, 0, -9);
        }
        else
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("water"))
            {
                Destroy(obj);
            }
            GameObject waterPosition = GameObject.Find("waterPosition");
            GameObject tempobj = Instantiate(objWater, waterPosition.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), waterPosition.transform) as GameObject;
            tempobj.transform.localPosition = new Vector3(0, 0, 0);
            tempobj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            tempobj.GetComponent<Animation>().enabled = true;
            tempobj.GetComponent<Animation>().Play("stopPour");
            if (Constant.missionNum == 13)
            {
                fire1.SetActive(true);
                fire2.SetActive(true);
                GameObject waterPosition2 = GameObject.Find("waterPosition2");
                GameObject tempobj2 = Instantiate(objWater, waterPosition2.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), waterPosition2.transform) as GameObject;
                tempobj2.transform.localPosition = new Vector3(0, 0, 0);
                tempobj2.transform.localRotation = Quaternion.Euler(0, 0, 0);
                tempobj2.GetComponent<Animation>().enabled = true;
                tempobj2.GetComponent<Animation>().Play("stopPour");
            }

        }

        goalText.GetComponent<Text>().text = Constant.goals[Constant.missionNum];
        resultGoalText.GetComponent<Text>().text = Constant.goals[Constant.missionNum];
        resultGoalText2.GetComponent<Text>().text = Constant.goals[Constant.missionNum];
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
                else
                    goalFail();

                break;
            case 8:
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
            case 9:
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

            case 10:
                if (Constant.isClearSubMission)
                    goalSuccess();
                else
                    goalFail();

                break;
            case 11:
                if (Constant.isClearSubMission)
                    goalSuccess();
                else
                    goalFail();

                break;
            case 12:
                if (Constant.isClearSubMission)
                    goalSuccess();
                else
                    goalFail();

                break;
            case 13:
                if (Constant.isClearSubMission && !Constant.isClearSubMission2)
                {
                    Constant.isClearSubMission = false;
                    Constant.isClearSubMission2 = true;
                }
                else if (Constant.isClearSubMission && Constant.isClearSubMission2)
                {
                    goalSuccess();
                }
                else
                    goalFail();

                break;
            case 14:
                if (Constant.isClearSubMission)
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
        isPlaying = false;
        failGoalPanel.SetActive(true);
    }

    private void goalSuccess()
    {
        isPlaying = false;
        StartCoroutine(waitGoal());

    }

    private IEnumerator waitGoal()
    {
        yield return new WaitForSeconds(0.5f);
        resultGoalPanel.SetActive(true);
    }


}
