using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceManager : MonoBehaviour
{
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        nextSence();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
      
                nextSence();
            
        


    }


    void nextSence()
    {

        int childCount = transform.childCount;
   
        if (currentIndex == childCount) return;
        for (int i = 0; i < childCount; i++)
        {


            transform.GetChild(i).gameObject.SetActive(i == currentIndex);
            //if (i == currentIndex)
            //{
            //    transform.GetChild(i).gameObject.SetActive(true);
            //}
            //else {

            //    transform.GetChild(i).gameObject.SetActive(false);
            //}
        }
        currentIndex++;



    }
    
}
