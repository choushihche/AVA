using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoController_8 : MonoBehaviour
{
    public VideoPlayer eyes;
    public RawImage videoDisplay;
    public Image background;

    // Start is called before the first frame update
    void Start()
    {
        eyes.Pause();
        if (background.IsActive())
        {
            eyes.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = eyes.texture;

    }

}
