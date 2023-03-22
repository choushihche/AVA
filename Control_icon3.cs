using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Video;

public class Control_icon3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator iconplay;
    public Image icon;
    public RawImage pic;
    public Button tip;
    public Button close;
    public VideoPlayer vp;

    void Start()
    {
        iconplay.Play("empty");
        close.gameObject.SetActive(false);
        pic.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowIcon()
    {
        if (vp.isPaused)
        {
            iconplay.Play("icon2");
            tip.gameObject.SetActive(false);
            close.gameObject.SetActive(true);
        }
        else 
        {
            iconplay.Play("icon");
            tip.gameObject.SetActive(false);
            close.gameObject.SetActive(true);
        }
    }
    public void CloseIcon()
    {
        tip.gameObject.SetActive(true);
        iconplay.Play("empty");
        close.gameObject.SetActive(false);

    }
}
