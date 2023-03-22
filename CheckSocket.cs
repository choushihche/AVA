using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class CheckSocket : MonoBehaviour
{
    public Image socketConnectedSignal;
    public Animator Load;
    public Image load;

    public int port = 7171;
    string editString = "hello wolrd"; //編輯框文字

    
    Socket serverSocket; //伺服器端socket
    IPAddress ip; //主機ip
    IPEndPoint ipEnd;
    string recvStr; //接收的字串
    string sendStr; //傳送的字串
    byte[] recvData = new byte[1000]; //接收的資料，必須為位元組
    byte[] sendData = new byte[1000]; //傳送的資料，必須為位元組
    int recvLen; //接收的資料長度
    Thread connectThread; //連線執行緒
    bool isGoToNextPage = false;
    bool isLoading = false;
    bool isWrong = false;
    public Animator Wrong;
    public Image wrong;
    public Image disconnect;

    //初始化
    void InitSocket()
    {
        if (serverSocket != null)
        {
            if (serverSocket.Connected) return;
        }
        //定義伺服器的IP和埠，埠與伺服器對應
        ip = IPAddress.Parse("172.20.10.2"); //可以是區域網或網際網路ip，此處是本機127.0.0.1 PU wifi10.0.34.102
        ipEnd = new IPEndPoint(ip, port);


        //開啟一個執行緒連線，必須的，否則主執行緒卡死
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    void SocketConnet()
    {
        if (serverSocket != null)
            serverSocket.Close();
        //定義套接字型別,必須在子執行緒中定義
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            serverSocket.Connect(ipEnd);
        }
        catch (Exception e)
        {

            print(e);
        }
        //連線





    }
    void SocketSend(string sendStr)
    {
        if (!serverSocket.Connected) return;
        //清空傳送快取
        sendData = new byte[1000];
        //資料型別轉換
        sendData = Encoding.ASCII.GetBytes(sendStr);
        //傳送
        serverSocket.Send(sendData, sendData.Length, SocketFlags.None);
       
    }
    public void Micky()
    {
        SocketSend("Check"); 
        //如果沒有連線的話需要跳出wrong 沒有連線也不能check
        isLoading = true;
    }
    void SocketReceive()
    {
        SocketConnet();
        //不斷接收伺服器發來的資料
        while (serverSocket.Connected)
        {
            recvData = new byte[1000];
            recvLen = serverSocket.Receive(recvData);
            if (recvLen == 0)
            {
                SocketConnet();
                continue;
            }
            recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
            print(recvStr);
            if (recvStr == "Yes!")
            {
                isGoToNextPage = true;
              

            }
            else if(recvStr == "NO!")
            {
                isWrong = true;
            }

            
        }
    }
    public void ChangeScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    void SocketQuit()
    {
        //關閉執行緒
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //最後關閉伺服器
        if (serverSocket != null)
            serverSocket.Close();
        print("diconnect");
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("InitSocket", 1.0f, 5.0f);
        load.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);
        disconnect.gameObject.SetActive(false);

    }
    // Update is called once per frame
    //需要一個確認網路連線狀況的警示訊息
    //收到圖但是封包不完整的錯誤訊息 收到"NO!"
    //loading送出就loading 收到"YES!"
    void Update()
    {
        if (serverSocket != null && socketConnectedSignal != null)
        {
            socketConnectedSignal.color = serverSocket.Connected ? Color.green : Color.red;
            if (socketConnectedSignal.color == Color.red)
            {
                disconnect.gameObject.SetActive(true);
                load.gameObject.SetActive(false);
            }
            else if(socketConnectedSignal.color == Color.green)
            {
                disconnect.gameObject.SetActive(false);
            }
        }

        if (isGoToNextPage)
        {
            isGoToNextPage = false;
            ChangeScene(1);
        }
        if (isLoading)
        {
            load.gameObject.SetActive(true);
            isLoading = false;
            Load.Play("loading");
            
        }
        if(isWrong)
        {
            wrong.gameObject.SetActive(true);
            load.gameObject.SetActive(false);
            isWrong = false;
            Wrong.Play("error");
           
        }
    }

    //程式退出則關閉連線
    //void OnApplicationQuit()
    //{
    //    SocketQuit();
    //}
    private void OnDisable()
    {
        SocketQuit();
    }

  
    
}
