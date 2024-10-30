using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//セレクトステージのスクリプト

public class SelectScript : MonoBehaviour
{
    //どのステージかのステージのテキスト
    public GameObject stageText;
    //移動するscene
    public string scene;
    //画面移動のシャッター
    public ShaterScript shater;
    //当たっているかどうか
    bool isCollison = false;
    //決定したときの音
    public AudioSource selectAudio;

    //触れているとき
    private void OnCollisionStay(Collision other)
    {
         if (other.gameObject.CompareTag("Player"))
        {

            //シャッターが開いているかで表示変更
            if (ShaterScript.isShaterOpen)
            {
                stageText.SetActive(true);
            }
            else
            {
                stageText.SetActive(false);
            }
            isCollison = true;
        }
    }
    /// 離れた時
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //非表示にする
                stageText.SetActive(false);
            
            
            isCollison = false;
        }
    }

    private void Update()
    {
        //isCollisonがtrueで一定時間たったらLoadScene
        if (isCollison&& shater.closeTimer >= 180)
        {
            
            SceneManager.LoadScene(scene);
        }



        //ステージ決定とシャッターを下す
        if ( (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown("joystick button 0"))&&
                isCollison)
        {
            selectAudio.Play();
            stageText.SetActive(false);
            ShaterScript.isShaterOpen = false;
        }


        
    }

    

    

}
