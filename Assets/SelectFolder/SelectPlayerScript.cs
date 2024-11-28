using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// セレクト画面のプレイヤー移動

namespace Kamata
{

}


public class SelectPlayerScript : MonoBehaviour
{
    // プレイヤーのRigidbody
    public Rigidbody rb;

    //プレイヤーの移動速度
    const float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのRigidbodyのvelocityを入れる
        Vector3 v = rb.velocity;
        //プレイヤーのpositionを入れる
        var pos = transform.position;

        // x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);
        // ｚ軸方向の移動範囲制限
        pos.z = Mathf.Clamp(pos.z, -5.5f, 5.5f);

        

       
        //ゲームパッドのスティック入力受け取り
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (!ShaterScript.isShaterOpen)
        {
            return;
        }

        //　プレイヤーの移動
        if (Input.GetKey(KeyCode.RightArrow)||moveX>0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)|| moveX<0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) || moveY > 0)
        {
            v.z = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.DownArrow) || moveY<0)
        {
            v.z = -moveSpeed;
        }
        else
        {
            v.z = 0;
        }

        rb.velocity = v;
        transform.position = pos;
    }
}
