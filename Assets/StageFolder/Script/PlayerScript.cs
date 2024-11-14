using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//　stageのプレイヤーの動き


public class PlayerScript : MonoBehaviour
{
    //Rigidbody
    public Rigidbody rb;
    //ブロックに触れているか
    private bool isBlock = true;
    //ジャンプした後の音
    public AudioSource jumpAudio;
    //お宝入手の音
    public AudioSource coinAudio;
    //ジャンプした回数
    int jumpCount = 0;
    // 移動スピード
    float moveSpeed = 5.0f;
    //初期の位置
    Vector3 startPos;

    


    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
    }

    
    
    //触れた時
    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);

            coinAudio.Play();
            //得点に追加
            GameManagerScript.score += 1;

            
        }

        //Groundのオブジェクトに触れたらジャンプリセット
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        


    }


    public void Reset()
    {
        transform.position = startPos;
    }


    // Update is called once per frame
    void Update()
    {
        //　rbの一時保存
        Vector3 v = rb.velocity;
        //　positionの一時保存
        var pos = transform.position;

       
        
        //足元の位置確認に使用
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        Ray ray = new Ray(rayPosition, transform.up * -1);

        float distance = 0.35f;

        
        float moveX = Input.GetAxis("Horizontal");

        //RaycastHit hit;
        isBlock = Physics.Raycast(ray, distance);

        

        // 穴に落ちた時初期位置に戻る
        if (transform.position.y <= -10.0f&& !GameOverScript.isGameOver&& !GameOverScript.isReset)
        {
            GameOverScript.isGameOver = true;
            
        }

        if (GameOverScript.isReset)
        {
            transform.position = startPos;
        }

        if (GameOverScript.isGameOver|| GameOverScript.isReset)
        {
            return;
        }


        //isBlockが反応してるかどうか
        if (isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
            Debug.Log(jumpCount);
        }
        else if
        (!isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }

        //ゲームクリアした後硬直
        if (GoalScript.isGameClear)
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;
            return;
        }

        //ポーズ画面中移動制限
        if(PauseManagerScript.isGamePouse|| !StartScript.isStart) 
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;

            return;
        }

        //プレイヤーの移動
        if (Input.GetKey(KeyCode.RightArrow) ||
            moveX > 0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)||
            moveX < 0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }
        //プレイヤー2回までジャンプ可能
        if ((Input.GetKeyDown(KeyCode.Space)||
            Input.GetKeyDown("joystick button 0"))
            &&jumpCount<2)
        {
            v.y = 5;


            jumpCount++;

            jumpAudio.Play();

            Debug.Log(jumpCount);

        }

        

        rb.velocity = v;
        transform.position = pos;
    }

    



}
