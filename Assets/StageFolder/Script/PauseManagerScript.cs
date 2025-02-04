using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//ポーズ画面

public class PauseManagerScript : MonoBehaviour
{
    // ポーズ画面のテキスト
    public GameObject gamePauseText;
    // ポーズ画面の選択テキスト
    public GameObject selectText;

    //確認用テキスト
    public GameObject OKText;
    public GameObject selectOkText;

    //　ポーズ画面かどうか
    public static bool isGamePouse = false;

    private bool isOk = false;

    private bool isBuck = false;

    //シャッター
    public ShaterScript shater;

    // Start is called before the first frame update
    void Start()
    {
        isGamePouse = false;
    }




    // Update is called once per frame
    void Update()
    {

        if (!isBuck&& StartScript.isStart)
        {

            if (!isOk)
            {
                //　ボタンを押したとき表示される
                if ((Input.GetKeyDown(KeyCode.X) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button7))
                    && !isGamePouse)
                {
                    gamePauseText.SetActive(true);
                    selectText.SetActive(true);

                    isGamePouse = true;
                }
                else if ((Input.GetKeyDown(KeyCode.X) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button7) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button0))
                    && isGamePouse)
                {
                    gamePauseText.SetActive(false);
                    selectText.SetActive(false);

                    isGamePouse = false;

                }
            }
            if (isGamePouse)
            {

                if (isOk)
                {
                    //セレクト画面に戻る
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        isBuck = true;
                        ShaterScript.isShaterOpen = false;
                    }

                    if ((Input.GetKeyDown(KeyCode.X) ||
                Input.GetKeyDown(KeyCode.Joystick1Button0)))
                    {
                        isOk = false;
                        OKText.SetActive(false);
                        selectOkText.SetActive(false);
                        gamePauseText.SetActive(true);
                        selectText.SetActive(true);
                    }


                }
                else
                {
                    //セレクト画面に戻る
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        isOk = true;
                        OKText.SetActive(true);
                        selectOkText.SetActive(true);
                        gamePauseText.SetActive(false);
                        selectText.SetActive(false);
                    }
                }

            }
        }
       

        //ゲームクリアして一定以上たったらシーン遷移
        if (shater.closeTimer >= 180 && isBuck)
        {

            SceneManager.LoadScene("SelectScene");
        }

    }
}
