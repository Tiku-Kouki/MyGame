using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        pos.x += 0.05f;

        if (pos.x >= 20.5f)
        {
            pos.x = -20.5f;
        }

        transform.position = pos;
    }
}
