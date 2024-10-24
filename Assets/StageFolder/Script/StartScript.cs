using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//スタート画面のスクリプト

public class StartScript : MonoBehaviour
{
    //Readyのテキスト
    public TextMeshProUGUI ReadyText;
    //Goのテキスト
    public TextMeshProUGUI GoText;
    // ReadyのSE
    public AudioSource readySE;
    // GoのSE
    public AudioSource goSE;
    //　スタートしたかの変数
    public static bool isStart = false;
    // Readyが表示されたか
    private bool isReady = false;
    // Readyが表示された時間
    private int readyTime = 0;
    // ReadyのSE
    private bool isReadySE = false;
    //　GoのSE
    private bool isGoSE = false;




    // Start is called before the first frame update
    void Start()
    {
        isStart = false;

        ReadyText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        GoText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


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

            GoText.transform.position= GoText.transform.position - new Vector3(50.0f,0.0f,0.0f);

            
        }



        if (GoText.transform.position.x <= 1400)
        {
            

            if (!isGoSE)
            {
                isGoSE=true;
                goSE.Play();
            }

            if (GoText.transform.position.x <= -400)
            {
                isStart = true;
            }

            
        }



       // enabled = false;

    }
}
