using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Video;

public class IconController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator iconplay;
    public Image icon;
    public Button tip;
    public Button close;

    void Start()
    {
        iconplay.Play("empty");
        close.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowIcon()
    { 
            iconplay.Play("icon");
            tip.gameObject.SetActive(false);
            close.gameObject.SetActive(true);
        
    }
    public void CloseIcon()
    {
        tip.gameObject.SetActive(true);
        iconplay.Play("empty");
        close.gameObject.SetActive(false);

    }
}

