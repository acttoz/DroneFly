using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyManager : MonoBehaviour
{
    public Sprite[] studyGroup1;
    public Sprite[] studyGroup2;
    public Sprite[] studyGroup3;
    public Sprite[] studyGroup4;
    public Sprite[] studyGroup5;
    public Sprite[] studyGroup6;
    public Sprite[] studyGroup7;
    public Sprite[] studyGroup8;
    public Sprite[] currentStudySprite;
    public GameObject title;
    public GameObject SpritePanel;
    Image componentSpriteImage;
    int currentPage=0;
    int allPage;

    // Use this for initialization
    void Start()
    {
        title.GetComponent<Text>().text = Constant.studyTitle[Constant.studyNum];
        componentSpriteImage = SpritePanel.GetComponent<Image>();

        switch (Constant.studyNum)
        {
            case 0:
                currentStudySprite = studyGroup1;
                break;
            case 1:
                currentStudySprite = studyGroup2;
                break;
            case 2:
                currentStudySprite = studyGroup3;
                break;
            case 3:
                currentStudySprite = studyGroup4;
                break;
            case 4:
                currentStudySprite = studyGroup5;
                break;
            case 5:
                currentStudySprite = studyGroup6;
                break;
            case 6:
                currentStudySprite = studyGroup7;
                break;
            case 7:
                currentStudySprite = studyGroup8;
                break;
        }

        allPage = currentStudySprite.Length;
        setPage();
    }

    public void nextImage() {
        if ((currentPage + 1) < allPage) {
            currentPage++;
            setPage();
        }
    }
    public void prevImage()
    {
        if ((currentPage) > 0)
        {
            currentPage--;
            setPage();
        }
    }

    private void setPage() {
        componentSpriteImage.sprite = currentStudySprite[currentPage];
    }


    // Update is called once per frame
    void Update()
    {

    }


}
