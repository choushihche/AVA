using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicUnstop : MonoBehaviour
{
    public GameObject musicPrefab;
    private GameObject musicObj;
    void Start()
    {
       
    }
    
    private void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update()
    {

        //if (gamename == "13"||gamename=="post")
        //{
        //    Destroy(gameObject);
        //}
        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(13);
        }
        string gamename = SceneManager.GetActiveScene().name;
        GameObject musicObj = GameObject.Find("music");

 


        if (gamename == "13"|| gamename == "openning" || gamename == "post"|| gamename == "end"|| gamename == "Draw")
        {
            if (musicObj != null)
            {
                print("Destroy" + gamename);
                Destroy(musicObj.gameObject);
                return;
            }
        }
        else {
            if (musicObj == null)
            {
                GameObject index = GameObject.Instantiate(musicPrefab);
                index.name = "music";
                index.transform.parent = this.transform;
            }
        }
     


    }
    public void jumpToSence(int senceIndex)
    {
        
    }

    

}
