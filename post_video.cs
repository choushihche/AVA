using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class post_video : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage videodisplay;
    public VideoPlayer post;
   
    

    void Start()
    {
        GameObject.Find("Main Camera/Canvas/RawImage").GetComponent<RawImage>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        videodisplay.texture = post.texture;
        if (post.isPlaying)
        {
            GameObject.Find("Main Camera/Canvas/RawImage").GetComponent<RawImage>().enabled = true;
        }
        if (post.isPaused == true)
        {
           
            SceneManager.LoadScene(2);
        }
        
    }
}
