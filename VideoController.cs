using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.Animations;
public class VideoController : MonoBehaviour
{
    public Button btnplay;
    public VideoPlayer wolf;
    public RawImage videoDisplay;
    public Animator iconplay;
    // Start is called before the first frame update
    void Start()
    {
        wolf.Pause();
        videoDisplay.gameObject.SetActive(false);
        btnplay.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       videoDisplay.texture = wolf.texture;
        if (wolf.isPlaying)
        {
            iconplay.Play("icon2");
        }

    }
   
    public void Onbtnplay()
    {
        videoDisplay.gameObject.SetActive(true);
        wolf.Play();
        btnplay.gameObject.SetActive(false);
    }

}
