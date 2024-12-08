using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//　お宝のスクリプト


public class TreasureScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        //常に回転
        transform.Rotate(0.5f, 0.0f, 0.0f);

        

        
    }
}
