
using UnityEngine;
using UnityEngine.SceneManagement; //Unity4.6之后的版本注意要加这个
using UnityEngine.UI;
public class startgame : MonoBehaviour
{
    
    public void OnStartGame(int SceneNumber)
    {
        //Application.LoadLevel(SceneNumber); //Unity4.6及之前版本的写法
        SceneManager.LoadScene(SceneNumber);   
    }
}