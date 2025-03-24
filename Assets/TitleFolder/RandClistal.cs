using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//タイトル画面で落とすクリスタルの処理

public class RandClistal : MonoBehaviour
{
    
    private float randPosY = - 6.0f;
    
    private float fastPosX;
    private float fastPosY = 14.0f;
    private float fastPosZ = 2.0f;
    //private float rotationY = 0.5f;
    private float doropSpeed = 0.05f;
    private float roteX;
    private float roteZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,doropSpeed,0);

        roteZ += Time.deltaTime * 20;
        

        transform.rotation = Quaternion.Euler(roteX, 0, roteZ);

        

        if (randPosY > transform.position.y)
        {
            randPosY = Random.Range(-8.0f, -6.0f);
            fastPosX = Random.Range(-8.0f, 8.0f);
            fastPosY = Random.Range(12.0f, 16.0f);
            roteZ = Random.Range(-20.0f, 20.0f);
            roteX = Random.Range(-30.0f, 40.0f);


            transform.position = new Vector3(fastPosX, fastPosY, fastPosZ);
        }


    }
}
