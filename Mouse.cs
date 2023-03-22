using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    GameObject objInHand = null;
    int currentIndex = 0;
    public Sprite[] background = new Sprite[5];
    public Image backgroundImage;
    private int backgroundIndex = 0;
    public Sprite[] foreground = new Sprite[5];
    public Image foregroundImage;
    private int foregroundIndex = 0;
    private Vector2 startPos;
    private double distance_threshold = 100.0;
    private int handIndex = 0;
    public GameObject handManager;
    private Vector3 offset;
    private Vector3 objStartPos;
    public AudioSource put;
    public Button next;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        currentIndex = 1;
        nextBackground();
        nextForeground();
        next.gameObject.SetActive(false);

    }
    void nextBackground()
    {
        backgroundImage.sprite = background[backgroundIndex];
        backgroundIndex++;
        if (backgroundIndex == background.Length) backgroundIndex = background.Length - 1;
    }
    void nextForeground()
    {
        foregroundImage.sprite = foreground[foregroundIndex];
        foregroundIndex++;
        if (foregroundIndex == foreground.Length) foregroundIndex = foreground.Length - 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            nextBackground();
        }
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetMouseButton(0))
        {
            if (objInHand == null)
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.mousePosition;
                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    Debug.Log("Hit " + result.gameObject.name);
                    if (result.gameObject.tag == "Dragable")
                    {
                        objInHand = result.gameObject;
                        startPos = Input.mousePosition;
                        offset = result.gameObject.transform.position - new Vector3(startPos.x, startPos.y, 0);
                        objStartPos = result.gameObject.transform.position;

                    }
                }
            }
            else
            {

                if (objInHand != null)
                {

                    objInHand.transform.position = Input.mousePosition + offset;

                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            float dis = Vector2.Distance(startPos, Input.mousePosition);
            if (dis < 400)
            {
                objInHand.transform.position = objStartPos;
                objInHand = null;

            }
            else
            {
                if (objInHand != null)
                {
                    objInHand.transform.position = objStartPos;
                    objInHand.gameObject.transform.tag = "Untagged";
                    objInHand.SetActive(false);
                    objInHand = null;
                    nextBackground();
                    nextForeground();
                    handIndex++;
                    put.Play();
                    if (handIndex < 4)
                    {
                        handManager.transform.GetChild(handIndex).gameObject.SetActive(true);

                        if (handIndex == 3)
                        {
                            next.gameObject.SetActive(true);
                        }
                    }



                }
            }
            //handManager.transform.GetChild(handIndex).gameObject.SetActive(true);




        }
    }
    void nextSence()
    {

        int childCount = transform.childCount;

        if (currentIndex == childCount) return;
        for (int i = 0; i < childCount; i++)
        {


            //transform.GetChild(i).gameObject.SetActive(i == currentIndex);
            if (i == currentIndex)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            else
            {

                transform.GetChild(i).gameObject.SetActive(false);
            }

        }
        currentIndex++;



    }


}

/* private void OnMouseDown()
 {
     print("OnMouseDown");
 }
 private void OnMouseDrag()
 {
     print("OnMouseDrag");
 }
 private void OnMouseUp()
 {
     print("OnMouseUp");
 }
}
*/
