using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class Mike_VideoController : MonoBehaviour
{
    private RawImage videoDisplay;
    private VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        videoDisplay = GetComponent<RawImage>();
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = vp.texture;
    }
}
