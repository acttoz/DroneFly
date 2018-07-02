using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public static int cardUp = 0;
    public static int cardDown = 1;
    public static int cardFoward = 2;
    public static int cardLeft = 3;
    public static int cardRight = 4;
    public static int cardRepeat = 5;
    public static int Levelnum;
    public int publicLevelnum;
    public static bool isGetBox = false;
    public static bool isClearSubMission = false;
    public static bool isGetFireExt = false;
    public static int height = 0;
    public static int repeatNum = 1;
    public static int currentSlotId = 0;
    public static int currentCardId = 0;
    public static int studyNum = 0;
    public static string[] studyTitle = { "드론 알아보기", "나만의 드론만들기", "드론 보드게임(개인)", "드론 보드게임(팀)", "스크래치", "순차 구조", "반복 구조", "선택 구조" };
    public static string[] cardTexts = { "상승", "하강", "전진", "좌회전", "우회전", "반복", "놓기" };
    public static string[] goals = { "미션1. 이륙 후 착륙하세요.", "미션2. 도착지까지 이동하세요.", "미션3. 도착지까지 이동하세요.", "미션4. 도착지까지 이동하세요.", "미션5. 도착지까지 이동하세요.", "미션6. 상자를 집어 보세요.", "미션7. 상자를 집어 집이 있는 곳까지 옮기세요.", "미션8. 상자를 집어 집까지 옮기고 도착점에 착륙하세요 .", "미션9. 상자를 집까지 옮기세요.", "미션10. 상자를 집까지 옮기세요.", "미션11. 물을 길어 장애물을 피해 불을 끄시오.", "미션12. 물을 길어 장애물을 피해 불을 끄시오.", "미션13. 물을 길어 장애물을 피해 불을 끄시오.", "미션14. 물을 길어 장애물을 피해 불을 끄시오.", "미션15. 물을 길어 장애물을 피해 불을 끄시오.", "앞으로 한칸 이동 하시오." };

    public static List<int> selectedCardIds;
    public static List<int> repeatList;
    public List<int> selectedCardpublic;
    public static int missionNum=0;
    public static bool isFlying = false;

    // Use this for initialization
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
            missionNum = publicLevelnum;
        selectedCardIds = new List<int>();
        selectedCardpublic = new List<int>();
        repeatList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        selectedCardpublic = selectedCardIds;
    }
}
