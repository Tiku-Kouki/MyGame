using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//セレクト画面のカメラの動き

public class SelectCameraScript : MonoBehaviour
{
    public GameObject player;

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
        position.y = playerPosition.y +1;
         position.z = playerPosition.z - 5;
        transform.position = position;

    }
}
