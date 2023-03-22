using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class LightSensor : MonoBehaviour
{
    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject jo = null;
    AndroidJavaClass activityClass = null;
    public Text text;
    float lightsensor;
    public Animator Breath;
    //public GameObject maskobj;
    public Press maskcontroller;
    private int lightSensorThreshold = 30;
   
    void Start()
    {
        Breath.gameObject.SetActive(true);
#if UNITY_ANDROID
        activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

		jo = new AndroidJavaObject("com.etiennefrank.lightsensorlib.LightSensorLib");
		jo.Call("init", activityContext);
#endif
        if (PlayerPrefs.HasKey("LightSensor"))
        {
            lightSensorThreshold = PlayerPrefs.GetInt("LightSensor");
        }
    }
    private void Update()
    {
        lightsensor=getLux();
        text.text = lightsensor.ToString();
        if (lightsensor <= lightSensorThreshold)
        {
            
            maskcontroller.isLightSensorPressed = true;
            Breath.enabled=false;
            

        }
        else
        {
            maskcontroller.isLightSensorPressed = false;
            Breath.gameObject.SetActive(true);
            Breath.enabled = true;


        }

    }

    public float getLux()
    {
#if UNITY_ANDROID
		return jo.Call<float>("getLux");
#endif
        return 0.0f;
    }

    }
