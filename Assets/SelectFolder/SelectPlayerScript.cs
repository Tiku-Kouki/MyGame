using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// セレクト画面のプレイヤー移動




public class SelectPlayerScript : MonoBehaviour
{
    // プレイヤーのRigidbody
    public Rigidbody rb;

    //プレイヤーの移動速度
    const float moveSpeed = 5.0f;
    //プレイヤーの半径
    private float radius;

    //ジャンプした後の音
    public AudioSource jumpAudio;

    //ジャンプした回数
    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x / 2f;
    }

    //触れた時
    private void OnCollisionEnter(Collision other)
    {
        //SelectFloorに乗っている間はジャンプ封印
        if (other.gameObject.CompareTag("SelectFloor"))
        {
            jumpCount = 3;

            return;
        } else
        //Groundのオブジェクトに触れたらジャンプリセット
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            GetComponent<Renderer>().material.color = Color.white;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 0.35f;
        // プレイヤーのRigidbodyのvelocityを入れる
        Vector3 v = rb.velocity;
        //プレイヤーのpositionを入れる
        var pos = transform.position;

        // x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);
        // ｚ軸方向の移動範囲制限
        //pos.z = Mathf.Clamp(pos.z, -5.5f, 5.5f);

        

       
        //ゲームパッドのスティック入力受け取り
        float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");

        if (!ShaterScript.isShaterOpen)
        {
            return;
        }

        //　プレイヤーの移動
        
        
        
        if (Input.GetKey(KeyCode.RightArrow) ||
            moveX > 0)
        {
            v.x = moveSpeed;
            float angle = (distance / radius) * Mathf.Rad2Deg;
            float direction = Mathf.Sign(moveX); // 左右で回転方向を変える
            //移動時に回転
            transform.Rotate(Vector3.back, angle * direction, Space.World);
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow) ||
            moveX < 0)
        {
            v.x = -moveSpeed;
            float angle = (distance / radius) * Mathf.Rad2Deg;
            float direction = Mathf.Sign(moveX); // 左右で回転方向を変える
            //移動時に回転
            transform.Rotate(Vector3.back, angle * direction, Space.World);

        }
        else
        {
            v.x = 0;
        }

        //プレイヤー2回までジャンプ可能
        if ((Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown("joystick button 0"))
            && jumpCount < 2)
        {
            v.y = 5;


            jumpCount++;

            jumpAudio.Play();

            Debug.Log(jumpCount);

        }

        //if (Input.GetKey(KeyCode.UpArrow) || moveY > 0)
        //{
        //    v.z = moveSpeed;
        //}
        //else
        //if (Input.GetKey(KeyCode.DownArrow) || moveY<0)
        //{
        //    v.z = -moveSpeed;
        //}
        //else
        //{
        //    v.z = 0;
        //}

        rb.velocity = v;
        transform.position = pos;
    }
}
