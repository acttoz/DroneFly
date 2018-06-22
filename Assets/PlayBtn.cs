using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    public Sprite playBtn;
    public Sprite resetBtn;
    private Button btn;
    private Image image;

    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        image = GetComponent<Image>();
        btn.onClick.AddListener(onClick);
    }
    void onClick()
    {
        if (Manager.isPlaying)
        {
            Manager.mgr.reset();
        }
        else
        {
            Manager.mgr.play();
        }
    }
    public void setPlayBtn()
    {
        image.sprite = playBtn;
    }
    public void setResetBtn()
    {
        image.sprite = resetBtn;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
