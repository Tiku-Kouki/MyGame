using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Rank;

//ステージのGameManager

public class GameManagerScript : MonoBehaviour
{
    //得点
    public static int score = 0;
    //得点の表示
    public TextMeshProUGUI scoreText;
    //得点の一定以上撮った時のランク
    public TextMeshProUGUI rankText;
    
    //背景BGM
    public AudioSource mainAudio;
    //シャッター
    public ShaterScript shater;
    //ゴールでの待機時間計算
    private int time = 0;
    [SerializeField]
    int BRankLine = 2, ARankLine = 4;


    private bool isPlayMusic = false;

    public static bool eraseGoalText = false;

    public RankScript rankScript;
    

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
        string rank = Rank.RankScript.C;

        

        if (StartScript.isStart&& !isPlayMusic&& !GoalScript.isGameClear)
        {
            mainAudio.Play();
            isPlayMusic = true;
        }

        if (GameOverScript.isGameOver)
        {
            mainAudio.Pause();
            mainAudio.time = 0;
            isPlayMusic = false;
        }
        



        //ゴールしたとき
        if (GoalScript.isGameClear)
        {
            mainAudio.Pause();

            time++;

            

            if (time > 240 && rankScript.isRankSet)
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
            rankText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }
        else if(!GoalScript.isGameClear) 
        {
            scoreText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            rankText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }


        //一定以上の時ランク変動
        if (score >= ARankLine)
        {
            rank = Rank.RankScript.A;
        }
        else if (score >= BRankLine && score < ARankLine)
        {
            rank = "B";
        }
        else if (score < BRankLine)
        {
            rank = "C";
        }
        //ランクと得点のそれぞれの表示
        rankText.text = rank;

        scoreText.text = "SCORE " + score;

    }
}
