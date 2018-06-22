using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour {
    public static int cardUp = 0;
    public static int cardDown = 1;
    public static int cardFoward = 2;
    public static int cardLeft = 3;
    public static int cardRight = 4;
    public static int cardRepeat = 5;
    public static string[] cardTexts = { "이륙", "하강", "전진", "좌회전", "우회전", "반복" };
    public static string[] goals = { "이륙 후 착륙하세요.", "도착지까지 이동하세요.", "도착지까지 이동하세요.", "도착지까지 이동하세요.", "도착지까지 이동하세요.", "상자를 집어 보세요.", "상자를 집어 집이 있는 곳까지 옮기세요.", "상자를 집어 집까지 옮기고 도착점에 착륙하세요 .", "상자를 집까지 옮기세요.", "상자를 집까지 옮기세요.", "물을 길어 장애물을 피해 불을 끄시오.", "물을 길어 장애물을 피해 불을 끄시오.", "물을 길어 장애물을 피해 불을 끄시오.", "물을 길어 장애물을 피해 불을 끄시오.", "물을 길어 장애물을 피해 불을 끄시오." };
 
    public static List<int> selectedCardIds;
    public List<int> selectedCardpublic;
	// Use this for initialization
	void Start () {
        Debug.Log("" + goals.Length);
        selectedCardIds = new List<int>();
        selectedCardpublic = new List<int>();

    }
	
	// Update is called once per frame
	void Update () {
        selectedCardpublic = selectedCardIds;
	}
}
