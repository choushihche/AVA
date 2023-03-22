using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoController_7 : MonoBehaviour
{
    public Button btnplay;
    public VideoPlayer run;
    public RawImage videoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera/Canvas/run").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Main Camera/Canvas/play").GetComponent<Button>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = run.texture;

    }

    public void Onbtnplay()
    {
        GameObject.Find("Main Camera/Canvas/run").GetComponent<RawImage>().enabled = true;
        GameObject.Find("Main Camera/Canvas/play").GetComponent<Button>().enabled = false;
        run.Play();

    }

}

