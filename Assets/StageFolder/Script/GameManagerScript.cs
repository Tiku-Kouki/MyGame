using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
//ステージのGameManager

public class GameManagerScript : MonoBehaviour
{
    //得点
    public static int score = 0;
    //得点の表示
    public TextMeshProUGUI scoreText;
    //得点の一定以上撮った時のランク
    public TextMeshProUGUI RankText;
    //背景BGM
    public AudioSource mainAudio;
    //シャッター
    public ShaterScript shater;
    //ゴールでの待機時間計算
    private int time = 0;

    private bool isPlayMusic = false;

    public static bool eraseGoalText = false;

    //public GameObject goalParticle;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        time = 0;

        isPlayMusic = false;
    }

    // Update is called once per frame
    void Update()
    {
        string Rank = "C";

        if (StartScript.isStart&& !isPlayMusic)
        {
            mainAudio.Play();
            isPlayMusic = true;
        }


        //ゴールしたとき
        if (GoalScript.isGameClear)
        {
            mainAudio.Pause();

            time++;

            if (time > 240)
            {
                if ((Input.GetKeyDown(KeyCode.Space) ||
                    Input.GetButtonDown("Jump"))&&
                    ShaterScript.isShaterOpen)
                {
                    eraseGoalText = true;
                    

                    ShaterScript.isShaterOpen = false;
                }
            }

        }

        //ゲームクリアして一定以上たったらシーン遷移
        if (shater.closeTimer>=180&& GoalScript.isGameClear)
        {
            
            SceneManager.LoadScene("SelectScene");
        }

        if (!StartScript.isStart|| !ShaterScript.isShaterOpen)
        {
            scoreText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            RankText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }
        else if(!GoalScript.isGameClear) 
        {
            scoreText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            RankText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }


        //一定以上の時ランク変動
        if (score >=4)
        {
            Rank = "A";
        }
        else if (score > 1 && score < 4)
        {
            Rank = "B";
        }
        else if (score <= 1)
        {
            Rank = "C";
        }
        //ランクと得点のそれぞれの表示
        RankText.text = "RANK " + Rank;

        scoreText.text = "SCORE " + score;

    }
}
