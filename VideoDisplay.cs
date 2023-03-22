using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoDisplay : MonoBehaviour
{
    public VideoPlayer end;
    public RawImage videoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera/Canvas/RawImage").GetComponent<RawImage>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = end.texture;
        if (end.isPlaying)
        {
            GameObject.Find("Main Camera/Canvas/RawImage").GetComponent<RawImage>().enabled = true;
        }


    }

}
