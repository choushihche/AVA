using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttoncontroller : MonoBehaviour
{

   
    public RawImage rawimage;
    public Texture[] tex;
    private int texIndex = 0;
    public Button btnnext;
    public Button btnbefore;
    public Button OnbtnBACKclick;

 
    // Update is called once per frame
    void Update()
    {

        rawimage.texture = tex[texIndex];
        if (texIndex <= 0)
        {
            texIndex = 0;
            btnbefore.gameObject.SetActive(false);

        }
        else
        {
            btnbefore.gameObject.SetActive(true);
        }
        if (texIndex >= tex.Length - 1)
        {
            texIndex = tex.Length - 1;
            btnnext.gameObject.SetActive(false);
        }
        else
        {
            btnnext.gameObject.SetActive(true);
        }
    }
    public void Onbtnnextclick()
    {
        texIndex = texIndex + 1;
        BGMcontroller myBGM = GameObject.Find("BGMcontroller").GetComponent<BGMcontroller>();
        myBGM.myAudioSource.PlayOneShot(myBGM.myButtonclip[0]);
    }

    public void Onbtnbackclick()
    {
        texIndex = texIndex - 1;
        BGMcontroller myBGM = GameObject.Find("BGMcontroller").GetComponent<BGMcontroller>();
        myBGM.myAudioSource.PlayOneShot(myBGM.myButtonclip[0]);

    }
    public void OnBackGame(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
        BGMcontroller myBGM = GameObject.Find("BGMcontroller").GetComponent<BGMcontroller>();
        myBGM.myAudioSource.PlayOneShot(myBGM.myButtonclip[1]);
    }


}

