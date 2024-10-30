using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// タイトルの上のトゲの動き


public class UpMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //　タイトルの上のトゲの位置
        var pos = transform.position;

        pos.x -= 0.05f;

        // 一定以上移動した時ループする
        if (pos.x <= -20.5f)
        {
            pos.x = 20.5f;
        }

        transform.position = pos;
    }
}
