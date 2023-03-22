using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMousedrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDrag()
    {
        Vector3 mos;
        mos = Input.mousePosition;
        gameObject.transform.position = new Vector3(mos.x, mos.y, 10);
     }
}
