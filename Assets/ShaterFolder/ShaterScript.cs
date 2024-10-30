using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ShaterScript : MonoBehaviour
{
    //シャッターのオブジェクト
    public GameObject shater;
    //シャッターが開いているか
    public  static bool isShaterOpen = true;
    //しまった時間経過
    public int closeTimer;
    //開閉のスピード
    public float speed = 0.01f;
    //最低位置
    public float downPos;
    //最大位置
    public float upPos;

    public static bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        isShaterOpen = true;
        closeTimer = 0;
    }
    void Update()
    {
        // isShaterOpenの状態によって関数が
        // 呼び出される
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

    //shaterを閉じる
    void DownPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y > downPos)
        {
            pos.y -= speed;

            shater.transform.position = pos;
        }
        else
        {
            shater.transform.position = new Vector3(shater.transform.position.x, downPos, shater.transform.position.z);

        }



    }

    //shaterを開く
    void UpPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y < upPos)
        {
            isUp = false;

            pos.y += speed;
            shater.transform.position = pos;

        }else if (pos.y >= upPos)
        {
            shater.transform.position = new Vector3(shater.transform.position.x, upPos, shater.transform.position.z);


            isUp = true;
            

        }
        closeTimer = 0;

    }

}
