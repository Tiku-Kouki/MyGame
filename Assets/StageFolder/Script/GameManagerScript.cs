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
    public TextMeshProUGUI RankText;
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
        string Rank = "C";

        if (StartScript.isStart&& !isPlayMusic)
        {
            mainAudio.Play();
            isPlayMusic = true;
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
            RankText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }
        else if(!GoalScript.isGameClear) 
        {
            scoreText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            RankText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }


        //���ȏ�̎������N�ϓ�
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
        //�����N�Ɠ��_�̂��ꂼ��̕\��
        RankText.text = "RANK " + Rank;

        scoreText.text = "SCORE " + score;

    }
}
