using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI RankText;

    public AudioSource mainAudio;

    private int time = 0;

    //public GameObject goalParticle;

    // Start is called before the first frame update
    void Start()
    {
        

        score = 0;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string Rank = "C";

        if (GoalScript.isGameClear)
        {
            mainAudio.Pause();

            time++;

            if (time > 240)
            {
                if (Input.GetKeyDown(KeyCode.Space) ||
                    Input.GetButtonDown("Jump"))
                {
                    SceneManager.LoadScene("SelectScene");
                }
            }

        }

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

        RankText.text = "RANK " + Rank;

        scoreText.text = "SCORE " + score;

    }
}
