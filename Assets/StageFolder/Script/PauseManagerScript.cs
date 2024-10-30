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
    //　ポーズ画面かどうか
    public static bool isGamePouse = false;

    

    // Start is called before the first frame update
    void Start()
    {
        isGamePouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        //　ボタンを押したとき表示される
        if ((Input.GetKeyDown(KeyCode.X)||
            Input.GetKeyDown(KeyCode.Joystick1Button7))
            &&!isGamePouse)
        {
            gamePauseText.SetActive(true);
            selectText.SetActive(true);

            isGamePouse = true;
        }else if ((Input.GetKeyDown(KeyCode.X) ||
            Input.GetKeyDown(KeyCode.Joystick1Button7)||
            Input.GetKeyDown(KeyCode.Joystick1Button0))
            && isGamePouse)
        {
            gamePauseText.SetActive(false);
            selectText.SetActive(false);

            isGamePouse = false;

        }else

        if (isGamePouse)
        {
            //セレクト画面に戻る
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                SceneManager.LoadScene("SelectScene");
            }


        }



    }
}
