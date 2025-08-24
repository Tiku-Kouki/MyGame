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

    [SerializeField]
    public GameObject Player;

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
        }else
        if(!isCollison && shater.closeTimer >= 180)
        {

            ShaterScript.isShaterOpen = true;
        }





        //ステージ決定とシャッターを下す
        if ((Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown("joystick button 0")) &&
                isCollison)
        {
            //Player.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y+1,this.transform.position.z);
            selectAudio.Play();
            stageText.SetActive(false);
            ShaterScript.isShaterOpen = false;
        }


        
    }

    

    

}
