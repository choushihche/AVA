using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Video;

public class IconController3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator iconplay;
    public Image icon;
    public Button tip;
    public Button close;
    public Image headup;

  
    void Start()
    {

        iconplay.SetInteger("States", 0);
        close.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            iconplay.SetInteger("States", 1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            iconplay.SetInteger("States", 2);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            iconplay.SetInteger("States", 3);
        }

    }
    public void ShowIcon()
    {
     
        tip.gameObject.SetActive(false);
        close.gameObject.SetActive(true);

    }
    public void CloseIcon()
    {
        tip.gameObject.SetActive(true);
        iconplay.SetInteger("States", 0);
        close.gameObject.SetActive(false);

    }
}

