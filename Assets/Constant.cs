using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour {
    public static int cardUp=0;
    public static int cardDown=1;
    public static int cardFoward=2;
    public static int cardLeft=3;
    public static int cardRight=4;
    public static int cardRepeat=5;
    public static string[] cardTexts = { "이륙", "하강", "전진", "좌회전", "우회전", "반복" };
    public static List<int> selectedCardIds;
    public List<int> selectedCardpublic;
	// Use this for initialization
	void Start () {
        selectedCardIds = new List<int>();
        selectedCardpublic = new List<int>();

    }
	
	// Update is called once per frame
	void Update () {
        selectedCardpublic = selectedCardIds;
	}
}
