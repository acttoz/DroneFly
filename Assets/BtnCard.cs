﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCard : MonoBehaviour
{
    public int idCard;
    Button btn;
    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClick);
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Constant.cardTexts[idCard];
    }

    private void onClick()
    {
        GetComponent<AudioSource>().Play();
        if (!Manager.isPlaying)
        {
            Constant.selectedCardIds.Add(idCard);
            try
            {
                Constant.repeatList.RemoveAt(Constant.currentSlotId);
            }
            catch (System.Exception E)
            {
            }
            Constant.repeatList.Insert(Constant.currentSlotId, Constant.repeatNum);
            Constant.repeatNum = 1;
            Constant.currentSlotId++;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
