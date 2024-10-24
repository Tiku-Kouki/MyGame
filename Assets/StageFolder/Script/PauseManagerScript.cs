using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//�|�[�Y���

public class PauseManagerScript : MonoBehaviour
{
    // �|�[�Y��ʂ̃e�L�X�g
    public GameObject GamePauseText;
    // �|�[�Y��ʂ̑I���e�L�X�g
    public GameObject SelectText;
    //�@�|�[�Y��ʂ��ǂ���
    public static bool isGamePouse = false;

    

    // Start is called before the first frame update
    void Start()
    {
        isGamePouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�@�{�^�����������Ƃ��\�������
        if ((Input.GetKeyDown(KeyCode.X)||
            Input.GetKeyDown(KeyCode.Joystick1Button7))
            &&!isGamePouse)
        {
            GamePauseText.SetActive(true);
            SelectText.SetActive(true);

            isGamePouse = true;
        }else if ((Input.GetKeyDown(KeyCode.X) ||
            Input.GetKeyDown(KeyCode.Joystick1Button7)||
            Input.GetKeyDown(KeyCode.Joystick1Button0))
            && isGamePouse)
        {
            GamePauseText.SetActive(false);
            SelectText.SetActive(false);

            isGamePouse = false;

        }else

        if (isGamePouse)
        {
            //�Z���N�g��ʂɖ߂�
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                SceneManager.LoadScene("SelectScene");
            }


        }



    }
}
