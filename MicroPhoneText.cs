using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class MicroPhoneText : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip micRecord;
    public Text text;
    private string device;
    float volume;
    public Animator suck;
    public Animator fun;
    public Animator monster;
    public Animator go;
    public Animator stupid;
    public Animator bitch;
    public Animator disgust;
    public Animator affectation;
    public Button next;


    private int currentStep = 0;
    private int volumeThreshold = 35;
    private bool waitBlow = true;



    void Start()
    {
        device = Microphone.devices[0];
        micRecord = Microphone.Start(device, true, 999, 44100);
        next.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        volume = GetVolume();
        text.text = volume.ToString();
        if (waitBlow && volume > volumeThreshold)
        {
            waitBlow = false;
            switch (currentStep)
            {
                case 0:
                    suck.Play("suck");
                    fun.Play("fun");
                    monster.Play("monster");
                    break;

                case 1:
                    go.Play("go");
                    stupid.Play("stupid");
                    bitch.Play("bitch");
                    break;

                case 2:
                    disgust.Play("disgust");
                    affectation.Play("affectation");
                    next.gameObject.SetActive(true);
                    break;

            }
            currentStep++;
            Invoke("resetWaitBlow", 1.5f);
        }
    }
    void resetWaitBlow()
    {
        waitBlow = true;
    }
    void Update()
    {

    }
    public float GetVolume()
    {
        if (Microphone.IsRecording(null))
        {
            int SampleSize = 128;
            float[] samples = new float[SampleSize];
            int startPosition = Microphone.GetPosition(device) - (SampleSize + 1);
            micRecord.GetData(samples, startPosition);
            float levelmax = 0;
            for (int i = 0; i < SampleSize; ++i)
            {
                float wavePeak = samples[i];
                if (levelmax < wavePeak)
                {
                    levelmax = wavePeak;
                }
            }
            return levelmax * 99;
        }
        return 0;

    }
}
