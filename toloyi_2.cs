using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class toloyi_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    //public Image pp;
    public VideoPlayer vp;
    public RawImage rw;
    public VideoPlayer vp2;
    public Button next;




    private const int STEP_ONE = 0;
    private const int STEP_TWO = 1;
    private const int STEP_THREE = 2;
    private int currentStep = STEP_ONE;


    void Start()
    {
        next.gameObject.SetActive(false);
        vp.Pause();
        vp.gameObject.SetActive(false);
        vp2.loopPointReached += VideoFinish;
    }

    // Update is called once per frame
    void Update()
    {
        rw.texture = vp.texture;
        int x = (int)(Input.acceleration.x * 180);
        int y = (int)(Input.acceleration.y * 180);
        int z = (int)(Input.acceleration.z * 180);
        text.text = (x + "     " + y + "     " + z + "     ").ToString();



        switch (currentStep)
        {
            case STEP_ONE:
                break;
            case STEP_TWO:
                if (x >= 70)
                {
                    //pp.color = Color.black;
                    next.gameObject.SetActive(true);
                    vp.gameObject.SetActive(true);
                    vp.Play();
                    currentStep = STEP_THREE;
                }
                break;
            case STEP_THREE:
                break;

        }



    }
    void VideoFinish(VideoPlayer vp)
    {
        currentStep = STEP_TWO;
    }


}
