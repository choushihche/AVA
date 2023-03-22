using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Animations;
using UnityEngine.Audio;



public class Mask : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    private Texture2D texture2D;
    public RawImage mask;
    public Texture texture;
    public Animator lightful;
    private int srcWidth = 2360, srcHeight = 1640;
    private Vector2 maskPos;
    
    public Button next;
    
    // Start is called before the first frame updatede
    void Start()
    {
        next.gameObject.SetActive(false);
        texture2D = TextureToTexture2D(texture);
        texture2D = convertTexture2DFormat(texture2D);
        mask.texture = texture2D;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        Vector2 pos = mask.GetComponent<RectTransform>().anchoredPosition;
        float scaleX = pos.x / srcWidth;
        float scaleY = pos.y / srcHeight;
        maskPos = mask.GetComponent<RectTransform>().anchoredPosition;

       // mask.GetComponent<RectTransform>().anchoredPosition = new Vector2(scaleX*Screen.width, scaleY*Screen.height);


    }
    
    // Update is called once per frame
    void Update()
    {

       // print(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            //Set up the new Pointer Event
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
                // Debug.Log("Hit " + result.gameObject.name + "result.screenPosition "+ result.screenPosition);

               // print(result.screenPosition + " " + mask.transform.position);
                if (result.gameObject.tag.Equals("mask"))
                {
                    Vector3 pos = result.screenPosition;
                    
                    Color32[] buffer = new Color32[100 * 100];
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = new Color32(255, 255, 255, 0);
                    }
                    int posX = (int)result.screenPosition.x -(int) maskPos .x- 50;
                    int posY =775 - (Screen.height- (int) result.screenPosition.y)+50;
                    
                    if (posX >= 51 && posX <= 499 && posY >=-30 && posY <= 649)
                    {
                        texture2D.SetPixels32(posX - 50, posY + 50, 100, 100, buffer);
                        texture2D.Apply();
                      
                    }

                    Color32[] colorBuffer = new Color32[texture2D.width * texture2D.height];
                    colorBuffer = texture2D.GetPixels32();
                    int alphaTotal = 0;
                    for (int i = 0; i < colorBuffer.Length; i++)
                    {
                        if (colorBuffer[i].a > 200)
                        {
                            alphaTotal++;
                        }
                    }
                    print("alphaTotal" + alphaTotal);
                    if (alphaTotal < 10000)
                    {
                        next.gameObject.SetActive(true);
                        lightful.Play("colorful");
           
                    }
                    
                    
                }
            }
        }
        
    }
    private Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

    
        return texture2D;
    }

    private Texture2D convertTexture2DFormat(Texture2D _input)
    {
        Texture2D _output = new Texture2D(_input.width, _input.height, TextureFormat.ARGB32, true);

        _output.SetPixels(_input.GetPixels());
        _output.Apply();
        return _output;

    }
   
}
