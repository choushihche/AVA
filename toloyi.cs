using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class toloyi : MonoBehaviour
{
    public Text text;
    public RawImage pic;
    public Texture[] tex;
    public int texIndex = 0;
    public bool trans;
    public AudioSource run1;
    public RawImage rw;
    public VideoPlayer vp;
    public Button next;
    public Image icon;
    public Button tip;
    public Button close;
    public Animator iconplay;


    // Start is called before the first frame update
    void Start()
    {
        trans = true;
        next.gameObject.SetActive(false);
        GameObject.Find("Main Camera/Canvas/crash").GetComponent<RawImage>().enabled = false;
        vp.Pause();
        iconplay.Play("empty");
        close.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rw.texture = vp.texture;
        pic.texture = tex[texIndex];
        int x = (int)(Input.acceleration.x * 180);
        int y = (int)(Input.acceleration.y * 180);
        int z = (int)(Input.acceleration.z * 180);
        text.text = (x + "     " + y + "     " + z + "     ").ToString();
        if (texIndex == tex.Length - 1)
        {
            GameObject.Find("Main Camera/Canvas/crash").GetComponent<RawImage>().enabled = true;
            next.gameObject.SetActive(true);
            vp.Play();
            texIndex++;        
        }
        if (x <= 60 && x >= -60)
        {
            trans = true;

        }
        else if (x>60)
        {
            change();

        }
        else
        {
            change();

        }



    }

    
    public void change()
    {
        if (trans == true)
        {
            trans = false;
            texIndex = texIndex + 1;

        }
        run1.Play();

    }
    public void ShowIcon()
    {
        if (texIndex>=tex.Length)
        {
            iconplay.Play("icon2");
            tip.gameObject.SetActive(false);
            close.gameObject.SetActive(true);
        }
        else 
        {
            iconplay.Play("icon");
            tip.gameObject.SetActive(false);
            close.gameObject.SetActive(true);
        }
    }
    public void CloseIcon()
    {
        tip.gameObject.SetActive(true);
        iconplay.Play("empty");
        close.gameObject.SetActive(false);

    }

}


