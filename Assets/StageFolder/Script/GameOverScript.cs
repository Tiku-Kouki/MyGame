using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //シャッターのオブジェクト
    public GameObject IrisUnmask;
    //Readyのテキスト
    public TextMeshProUGUI GameOverText;
    //Goのテキスト
    public TextMeshProUGUI YesNoText;
    //シャッター
    public ShaterScript shater;

    //シャッターが開いているか
    public static bool isGameOver = false;
    // アリスアウトするスピード
    public float IrisSpeed = 0.5f;

    private bool isSet = false;
    
    //シャッターが開いているか
    public static bool isReset = false;

    private bool isBackSelect = false;

    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        GameOverText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        YesNoText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            if (IrisUnmask.gameObject.transform.lossyScale.x !=0)
            {

                this.transform.localScale = new Vector3(IrisSpeed, IrisSpeed, 0);
                IrisUnmask.transform.localScale -= this.transform.localScale;

                Debug.Log(IrisUnmask.gameObject.transform.lossyScale.x);
            }
            else if(IrisUnmask.gameObject.transform.lossyScale.x <= 0)
            {
                isSet = true;
            }

        }else 
        if (!isGameOver)
        {
            IrisUnmask.transform.localScale = new Vector3(30.0f, 30.0f, 0.0f);
            if (GameOverText.color.a >= 0.0f)
            {
                GameOverText.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f);
            }
            YesNoText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }

        if (isSet)
        {
            if (GameOverText.color.a < 1.0f)
            {
                GameOverText.color += new Color(0.0f, 0.0f, 0.0f, 0.1f);
            }



            if (GameOverText.color.a >= 1.0f)
            {
                YesNoText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


                //セレクト画面に戻る
                if (Input.GetKeyDown(KeyCode.Joystick1Button2) && !isReset)
                {
                    isBackSelect = true;
                    ShaterScript.isShaterOpen = false;
                    
                    isSet = false;
                }
                
                
                if (Input.GetKeyDown("joystick button 0") && !isBackSelect)
                {
                    GameOverText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    ShaterScript.isShaterOpen = false;
                    isReset = true;
                    isSet = false;
                    
                }
            }
        }


        if (shater.closeTimer >= 180 && isBackSelect)
        {
            isGameOver = false;
            SceneManager.LoadScene("SelectScene");
        }

        if (isReset)
        {
            GameOverText.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f);
        }

        if (shater.closeTimer >= 180 && isReset)
        {
            
            isGameOver = false;
            
            isReset = false;
            ShaterScript.isShaterOpen = true;
        }


    }
}
