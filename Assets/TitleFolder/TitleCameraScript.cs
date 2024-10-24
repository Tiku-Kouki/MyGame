using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//タイトルのカメラ


public class TitleCameraScript : MonoBehaviour
{
    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //カメラの固定
        var titlePosition = title.transform.position;
        var position = transform.position;
        position.x = titlePosition.x;
        position.y = titlePosition.y;
        transform.position = position;

    }
}
