using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//タイトルのスクリプト

public class TitleScript : MonoBehaviour
{
    //　Aボタンを押すの表示オブジェクト
    public GameObject hitKey;
   
    //　hitKeyの点滅に使用
    private int timer = 0;
    //　ステージ移動時間の制限に使用
    private int startTimer = 0;
    // 音
    public AudioSource hitKeyAudio;
    //　ボタンを押したかどうか
    bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        //スクリーンの比率変更
        Screen.SetResolution(1920, 1080, false);
        timer = 0;
        startTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //シャッターが開いている間点滅
        if (ShaterScript.isShaterOpen)
        {
            timer++;
        }

        if (timer % 100 > 70)
        {
            hitKey.SetActive(false);
        }
        else
        {
            if (ShaterScript.isShaterOpen)
            {
                hitKey.SetActive(true);
            }
            else
            {
                hitKey.SetActive(false);
            }
            
        }


        //対応するボタンを押してisStartを
        //trueにする
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetButtonDown("Jump"))
        {
            hitKeyAudio.Play();
            ShaterScript.isShaterOpen = false;
            isStart = true;
        }

        if (isStart)
        {
            startTimer += 1;
        }

        //startTimerが160以上になった時シーン遷移
        if (startTimer>=160)
        {
            
            SceneManager.LoadScene("SelectScene");
        }


        


    }
}
