using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;
public class opmusic : MonoBehaviour
{
    public AudioSource op;
    void Start()
    {
        DontDestroyOnLoad(op);
    }
    private void Awake()
    {

    }
    void Update()
    {
        string gamename = SceneManager.GetActiveScene().name;
        if (gamename == "1")
        {
            Destroy(op);
        }



    }
}
