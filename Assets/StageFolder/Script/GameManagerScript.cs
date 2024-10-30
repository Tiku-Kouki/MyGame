using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
//�X�e�[�W��GameManager

public class GameManagerScript : MonoBehaviour
{
    //���_
    public static int score = 0;
    //���_�̕\��
    public TextMeshProUGUI scoreText;
    //���_�̈��ȏ�B�������̃����N
    public TextMeshProUGUI rankText;
    //�w�iBGM
    public AudioSource mainAudio;
    //�V���b�^�[
    public ShaterScript shater;
    //�S�[���ł̑ҋ@���Ԍv�Z
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
        string rank = "C";

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
        



        //�S�[�������Ƃ�
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

        //�Q�[���N���A���Ĉ��ȏソ������V�[���J��
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


        //���ȏ�̎������N�ϓ�
        if (score >=4)
        {
            rank = "A";
        }
        else if (score > 1 && score < 4)
        {
            rank = "B";
        }
        else if (score <= 1)
        {
            rank = "C";
        }
        //�����N�Ɠ��_�̂��ꂼ��̕\��
        rankText.text = "RANK " + rank;

        scoreText.text = "SCORE " + score;

    }
}
