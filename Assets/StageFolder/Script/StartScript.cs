using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//�X�^�[�g��ʂ̃X�N���v�g

public class StartScript : MonoBehaviour
{
    //Ready�̃e�L�X�g
    public TextMeshProUGUI ReadyText;
    //Go�̃e�L�X�g
    public TextMeshProUGUI GoText;
    // Ready��SE
    public AudioSource readySE;
    // Go��SE
    public AudioSource goSE;
    //�@�X�^�[�g�������̕ϐ�
    public static bool isStart = false;
    // Ready���\�����ꂽ��
    private bool isReady = false;
    // Ready���\�����ꂽ����
    private int readyTime = 0;
    // Ready��SE
    private bool isReadySE = false;
    //�@Go��SE
    private bool isGoSE = false;

    float sppedUp = 0;


    // Start is called before the first frame update
    void Start()
    {
        isStart = false;

        ReadyText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        GoText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        sppedUp = 0;

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

        if (readyTime >= 60&& !isStart)
        {
            if (ReadyText.color.a > 0)
            {
                ReadyText.color = ReadyText.color - new Color(0.0f, 0.0f, 0.0f, 0.05f);

            }

            sppedUp++;

            GoText.transform.position= GoText.transform.position - new Vector3(30.0f+ sppedUp, 0.0f,0.0f);

            
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
