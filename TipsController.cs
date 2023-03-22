using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipsController : MonoBehaviour
{

    public Text buttonText;
    public GameObject icon;
    private bool isShow = false;
    private Animator animator;
    private int IconIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = icon.GetComponent<Animator>();
        IconIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void tipButtonClick()
    {
        isShow = !isShow;
        buttonText.text = isShow ?  "CLOSE": "TIPS" ;
        if (!isShow)
        {
            animator.Play("empty");
            animator.SetInteger("States", 0);
        }
        else {
            animator.SetInteger("States", IconIndex);
        }
        
    }

    public void setIconIndex(int index)
    {
       
        IconIndex = index;
    }

}
