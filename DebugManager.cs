using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class DebugManager : MonoBehaviour
{
    public GameObject debugPage;
    public InputField lightSensorInput;
    

    // Start is called before the first frame update
    void Start()
    {
        debugPage.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        print("deubg" + lightSensorInput.text);
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            print(count);

        }

    }
    public void saveValue()
    {
        int lightSensorValue;
        bool isSuccessful = int.TryParse(lightSensorInput.text.ToString(), out lightSensorValue);
        if (isSuccessful)
        {
            PlayerPrefs.SetInt("LightSensor", lightSensorValue);
        }
    }
    public void loadValue()
    {
        if (PlayerPrefs.HasKey("LightSensor"))
        {
            int lightSensorValue = PlayerPrefs.GetInt("LightSensor");
            lightSensorInput.text = lightSensorValue.ToString();
        }
    }
    int count = 0;
    public void ShowDebug()
    {
            if (count >= 10)
            {
                debugPage.SetActive(true);
                count = 0;
            }

        

    }
    public void CloseDebug()
    {
         debugPage.SetActive(false);
    }
   
    }


