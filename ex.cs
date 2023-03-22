using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ex : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
   

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {
            text.text = (Screen.height + " " + Screen.width + " "+Input.mousePosition).ToString();
        }

    }




}
