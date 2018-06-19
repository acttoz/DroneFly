﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    public int slotId;
    private Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClick);
	}
	
	// Update is called once per frame
	void Update () {
        if (Constant.selectedCardIds.Count > slotId)
        {
            setCard();
        }
        else {
        }
	}
    void setCard() {
        int cardId= Constant.selectedCardIds[slotId];
        string slotText = Constant.cardTexts[cardId];
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = slotText;
    }
    void onClick() {
        Manager.o.GetComponent<Manager>().resetSlots();
        if (Constant.selectedCardIds.Count > slotId)
            Constant.selectedCardIds.RemoveAt(slotId);
    }

    public void reMoveCard()
    {
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
