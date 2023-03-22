using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.Animations;



public class headup : MonoBehaviour
{
    // Start is called before the first frame update
    public Button up;
    public Button text;
    public Image head;
    public Image headown;
    public Animator lightful;
    public Button next;
    void Start()

    {
        lightful.gameObject.SetActive(false);
        head.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Onheadup()
    {
        head.gameObject.SetActive(true);
        headown.gameObject.SetActive(false);
        text.gameObject.SetActive(true);

    }
    public void showlight()
    {
        next.gameObject.SetActive(true);
        lightful.gameObject.SetActive(true);
        lightful.Play("light");
    }

}
