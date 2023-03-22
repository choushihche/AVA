using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource a1;
    public AudioSource a2;
    public AudioSource a3;
    public AudioSource a4;
    public AudioSource a5;
    public AudioSource a6;
    public AudioSource a7;
    public AudioSource a8;
    public AudioSource a9;

    public Button next;

    void Start()
    {
        next.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (a1.mute&&a2.mute&& a3.mute && a4.mute && a5.mute && a6.mute && a7.mute && a8.mute && a9.mute)
        {
            next.gameObject.SetActive(true);
        }
       
    }
}
