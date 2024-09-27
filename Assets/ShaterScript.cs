using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ShaterScript : MonoBehaviour
{
    public GameObject shater;

    public  static bool isShaterOpen = true;

    public int closeTimer;

    float speed = 0.01f;

    public float downPos;
    public float upPos;


    // Start is called before the first frame update
    void Start()
    {
        isShaterOpen = true;
        closeTimer = 0;
    }
    void Update()
    {
        if (isShaterOpen)
        {
            UpPosition();
        }
        else
        if (!isShaterOpen)
        {
            DownPosition();

            closeTimer += 1;
        }
       

    }

    
    void DownPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y > downPos)
        {
            pos.y -= speed;

            shater.transform.position = pos;
        }
        
       
        
    }


    void UpPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y < upPos)
        {
            pos.y += speed;
            shater.transform.position = pos;

        }

        

    }

}
