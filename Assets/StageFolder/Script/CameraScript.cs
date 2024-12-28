using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stageのカメラの動き


public class CameraScript : MonoBehaviour
{
    public GameObject player;

    const int purasePos = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //　プレイヤーの位置
        var playerPosition = player.transform.position;
        //　カメラの位置
        var position = transform.position;
        //カメラがプレイヤーに追従
        position.x = playerPosition.x;
        if(playerPosition.y > -5)
        {
            position.y = playerPosition.y + purasePos;
        } 
       
        
        transform.position = position;

    }
}
