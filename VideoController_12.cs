using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoController_12 : MonoBehaviour
{
    public Button btntext;
    public VideoPlayer spotlight;
    public RawImage videoDisplay;
    public Image like;
    public Image headup;
    // Start is called before the first frame update
    void Start()
    {
        spotlight.gameObject.SetActive(false);
        like.gameObject.SetActive(false);
        spotlight.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = spotlight.texture;
        

    }

    public void Onbtnplay()
    {
        spotlight.gameObject.SetActive(true);
        spotlight.Play();
        headup.gameObject.SetActive(false);
        like.gameObject.SetActive(true);
    }
}
