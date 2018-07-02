using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotId;
    private Button btn;
    public Sprite cardColor;
    public Sprite emptyColor;
    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        try {
            if (Constant.repeatList[slotId] > 1)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).GetChild(0).GetComponent<Text>().text = Constant.repeatList[slotId] + "";
            }
            else {
                transform.GetChild(1).gameObject.SetActive(false);
            }
        } catch (Exception E) {  }
        

        if (Constant.currentSlotId > slotId)
        {
            setCard();
        }
        else
        {
        }
    }
    void setCard()
    {
        int cardId = Constant.selectedCardIds[slotId];
        string slotText = Constant.cardTexts[cardId];
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = slotText;
        GetComponent<Image>().sprite = cardColor;

    }
    void onClick()
    {
        Manager.mgr.resetSlots();
        if (Constant.currentSlotId > slotId)
        {
            Constant.currentSlotId--;
            Constant.selectedCardIds.RemoveAt(slotId);
            Constant.repeatList.RemoveAt(slotId);
        }
        
    }

    public void reMoveCard()
    {
        GetComponent<Image>().sprite = emptyColor;
        transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
