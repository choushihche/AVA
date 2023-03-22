using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using ProtoTurtle.BitmapDrawing;

// ...

//Texture2D texture = new Texture2D(1024, 1024, TextureFormat.RGB24, false, true);
//texture.filterMode = FilterMode.Point;
//texture.wrapMode = TextureWrapMode.Clamp;
//texture.DrawFilledRectangle(new Rect(0, 0, TEXTURE_SIZE, TEXTURE_SIZE), Color.grey);

//texture.DrawCircle(100, 100, 20, Color.green);
//texture.DrawCircle(80, 150, 5, Color.blue);
//texture.DrawCircle(300, 300, 200, Color.black);
//texture.FloodFill(100, 100, Color.green);
//texture.FloodFill(300, 300, Color.white);
//texture.DrawLine(new Vector2(10, 10), new Vector2(400, 200), Color.magenta);
//texture.DrawLine(new Vector2(400, 200), new Vector2(100, 200), Color.magenta);
//texture.Apply();


public class DrawSystem : MonoBehaviour
{
    
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public RawImage sourceImage;
    public GameObject Panelcolor;
    public GameObject Panelpen;
    public Text penWidthText;
    public Slider penWidthSlider;
    private Texture2D texture;
    private int penWidth = 10;
    private Color32 penColor;
    private Color32[] colorBuffer;
    private Color32[] defaultColor = new Color32[]
    {
        new Color32(188,0,95,255),
        new Color32(188,70,0,255),
        new Color32(118,164,0,255),
        new Color32(0,188,186,255),
        new Color32(172,35,255,255),
    };



    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        texture = TextureToTexture2D(sourceImage.texture);
        colorBuffer = new Color32[penWidth * penWidth];
        for (int i = 0; i < colorBuffer.Length; i++)
        {
            colorBuffer[i] = new Color32(188, 0, 95, 255);
        }
        penColor = defaultColor[0];
        
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButton(0))//GetMouseDown
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
                if (result.gameObject.tag == "drawable")
                {
                    Vector2 texturePos = result.screenPosition - new Vector2(sourceImage.GetComponent<RectTransform>().position.x, sourceImage.GetComponent<RectTransform>().position.y);

                    texturePos.y =  -texturePos.y;
                    
                    texture.DrawFilledCircle((int)texturePos.x, (int)texturePos.y, penWidth, penColor);
                    //Debug.Log("Hit " + texturePos + " "+ sourceImage.GetComponent<RectTransform>().position);
                    // texture.SetPixels32((int)texturePos.x, (int)texturePos.y, penWidth, penWidth, colorBuffer);
                    texture.Apply();
                    sourceImage.texture = texture;
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
        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        return texture2D;
    }

    public void setPenColor(Color32 color)
    {
        penColor = color;
        for (int i = 0; i < colorBuffer.Length; i++)
        {
            colorBuffer[i] = penColor;
        }
    }
    public void setColorIndex(int index)
    {
        setPenColor(defaultColor[index]);
    }
    public void setPenWidth(int width)
    {
        penWidth = width;
        colorBuffer = new Color32[width * width];
        setPenColor(penColor);
    }
    public void penWidthChange(int penindex)
    {
        int[] pen = new int[] {10,14,16,18,20};
        setPenWidth(pen[penindex]);

        //penWidth = (int)(penWidthSlider.value * 10) + 10;
        //setPenWidth(penWidth);
        //penWidthText.text = "Pen Width : " + penWidth;
    }
    public void ControlColorShow()
    {

        if (Panelcolor.activeSelf)
        {
            Panelcolor.SetActive(false);
        }
        else
        {
            Panelcolor.SetActive(true);
        }
    }
    public void ControlPenShow()
    {

        if (Panelpen.activeSelf)
        {
            Panelpen.SetActive(false);
        }
        else
        {
            Panelpen.SetActive(true);
        }
    }



}
