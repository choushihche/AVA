using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMcontroller : MonoBehaviour
{
    public AudioClip[] myBGMClip;
    public AudioClip[] myButtonclip;
    [HideInInspector]public AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        string gamename = SceneManager.GetActiveScene().name;

        if (gamename == "openning")
        {
            myAudioSource.clip = myBGMClip[0];
            myAudioSource.loop = true;
            myAudioSource.Play();

        }
        else if (gamename == "1")
        {
            myAudioSource.clip = myBGMClip[1];
            myAudioSource.loop = true;
            myAudioSource.Play();

        }
        else if (gamename == "2")
        {
            myAudioSource.clip = myBGMClip[1];
            myAudioSource.loop = true;
            myAudioSource.Play();

        }
    }

}
