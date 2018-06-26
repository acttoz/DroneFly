using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRepeat : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addRepeat()
    {
        Constant.repeatNum++;
        try {
        Constant.repeatList.RemoveAt(Constant.currentSlotId);
        }
        catch (System.Exception E) {
        }
        Constant.repeatList.Insert(Constant.currentSlotId, Constant.repeatNum);

    }
}
