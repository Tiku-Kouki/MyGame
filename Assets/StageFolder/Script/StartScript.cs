using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class StartScript : MonoBehaviour
{
    //Readyのテキスト
    public TextMeshProUGUI ReadyText;
    //Goのテキスト
    public TextMeshProUGUI GOText;
    // ReadyのSE
    public AudioSource readySE;
    // GoのSE
    public AudioSource goSE;
    //　スタートしたかの変数
    public static bool isStart = false;
    //
     //private int time = 0;

    private bool isReady = false;

     private int readyTime = 0;

    private bool isReadySE = false;

    private bool isGoSE = false;




    // Start is called before the first frame update
    void Start()
    {
        isStart = false;

        ReadyText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        GOText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    }

    // Update is called once per frame
    void Update()
    {
       if(!isReadySE && ShaterScript.isUp)
        {
            readySE.Play();
            isReadySE = true;
        }

        if (!isReady && ShaterScript.isUp)
        {

            if (ReadyText.color.a < 1)
            {
                ReadyText.color = ReadyText.color + new Color(0.0f, 0.0f, 0.0f, 0.1f);

            }
            else if (ReadyText.color.a >= 1)
            {
                isReady = true;

                Debug.Log(isReady);
            }

        }
        else if(isReady&&!isStart)
        {
            readyTime++;

        }

        if (readyTime >= 120&& !isStart)
        {
            if (ReadyText.color.a > 0)
            {
                ReadyText.color = ReadyText.color - new Color(0.0f, 0.0f, 0.0f, 0.05f);

            }

            GOText.transform.position= GOText.transform.position - new Vector3(50.0f,0.0f,0.0f);

            
        }



        if (GOText.transform.position.x <= 1400)
        {
            

            if (!isGoSE)
            {
                isGoSE=true;
                goSE.Play();
            }

            if (GOText.transform.position.x <= -400)
            {
                isStart = true;
            }

            
        }



       // enabled = false;

    }
}
