using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public GameObject hitKey;

    public ShaterScript shater;

    private int timer = 0;

    private int startTimer = 0;

    public AudioSource hitKeyAudio;

    bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        timer = 0;
        startTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShaterScript.isShaterOpen)
        {
            timer++;
        }
        if (timer % 100 > 70)
        {
            hitKey.SetActive(false);
        }
        else
        {
            if (ShaterScript.isShaterOpen)
            {
                hitKey.SetActive(true);
            }
            else
            {
                hitKey.SetActive(false);
            }
            
        }

        

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetButtonDown("Jump"))
        {
            hitKeyAudio.Play();
            ShaterScript.isShaterOpen = false;
            isStart = true;
        }

        if (isStart)
        {
            startTimer += 1;
        }

        if (startTimer>=160)
        {
            
            SceneManager.LoadScene("SelectScene");
        }


        


    }
}
