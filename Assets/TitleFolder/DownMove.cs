using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// タイトルの下のトゲの動き

public class DownMove : MonoBehaviour
{
    private const float loopPoint = 20.5f;
    private const float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // タイトルの下のトゲの位置
        var pos = transform.position;

        pos.x += speed;

        // 一定以上移動した時ループする
        if (pos.x >= loopPoint)
        {
            pos.x = -loopPoint;
        }

        transform.position = pos;
    }
}
