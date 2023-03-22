using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class Press : MonoBehaviour
{
    bool isPress = false;
    float MaskIndex = 0.0f;
    public GameObject Mask;
    public bool isLightSensorPressed = false;
    public Animator Breath;
    public Button next;
 

    // Start is called before the first frame update
    void Start()
    {
        Breath.gameObject.SetActive(true);
        Breath.Play("breath");
        next.gameObject.SetActive(false);
        
    }
    private void FixedUpdate()
    {
        if (isPress)
        {
            MaskIndex += 0.005f;
           
            if (MaskIndex > 1.0f)
            {
                MaskIndex = 1.0f;
               
            }      
            if (MaskIndex == 1.0f)
            {
                next.gameObject.SetActive(true);
                Breath.gameObject.SetActive(false);
            }
          
                
        }
        else
        {
            if (MaskIndex < 0.5f)
            {
                MaskIndex -= 0.015f;
            }
            if (MaskIndex < 0.0f)
            {
                MaskIndex = 0.0f;
            }
            else
            {
                MaskIndex += 0.005f;
            }

        }
        Mask.GetComponent<RawImage>().material.SetFloat("_ThresholdRight", MaskIndex);


    }
    // Update is called once per frame
    void Update()
    {
         if ((Input.GetMouseButton(0) && Input.mousePosition.x < 300 && Input.mousePosition.y <742 )||  (isLightSensorPressed))
        {
            Breath.enabled = false;
            print("Press");
            isPress = true;
            return;
        }
        else
        {
            Breath.enabled = true;
        }
       
        
        isPress = false;
    }
}
