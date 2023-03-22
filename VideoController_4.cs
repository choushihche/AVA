using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoController_4 : MonoBehaviour
{
    public Button btnplay;
    public VideoPlayer falling;
    public RawImage videoDisplay;
    public Button next;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera/Canvas/falling").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Main Camera/Canvas/PLAY").GetComponent<Button>().enabled = true;
        next.gameObject.SetActive(false);
        falling.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        videoDisplay.texture = falling.texture;

    }

    public void Onbtnplay()
    {
        next.gameObject.SetActive(true);
        GameObject.Find("Main Camera/Canvas/falling").GetComponent<RawImage>().enabled = true;
        GameObject.Find("Main Camera/Canvas/PLAY").GetComponent<Button>().enabled = false;
        falling.Play();

    }

}

