using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//�|�[�Y���

public class PauseManagerScript : MonoBehaviour
{
    // �|�[�Y��ʂ̃e�L�X�g
    public GameObject gamePauseText;
    // �|�[�Y��ʂ̑I���e�L�X�g
    public GameObject selectText;

    //�m�F�p�e�L�X�g
    public GameObject OKText;
    public GameObject selectOkText;

    //�@�|�[�Y��ʂ��ǂ���
    public static bool isGamePouse = false;

    private bool isOk = false;

    private bool isBuck = false;

    //�V���b�^�[
    public ShaterScript shater;

    // Start is called before the first frame update
    void Start()
    {
        isGamePouse = false;
    }




    // Update is called once per frame
    void Update()
    {

        if (!isBuck&& StartScript.isStart)
        {

            if (!isOk)
            {
                //�@�{�^�����������Ƃ��\�������
                if ((Input.GetKeyDown(KeyCode.X) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button7))
                    && !isGamePouse)
                {
                    gamePauseText.SetActive(true);
                    selectText.SetActive(true);

                    isGamePouse = true;
                }
                else if ((Input.GetKeyDown(KeyCode.X) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button7) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button0))
                    && isGamePouse)
                {
                    gamePauseText.SetActive(false);
                    selectText.SetActive(false);

                    isGamePouse = false;

                }
            }
            if (isGamePouse)
            {

                if (isOk)
                {
                    //�Z���N�g��ʂɖ߂�
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        isBuck = true;
                        ShaterScript.isShaterOpen = false;
                    }

                    if ((Input.GetKeyDown(KeyCode.X) ||
                Input.GetKeyDown(KeyCode.Joystick1Button0)))
                    {
                        isOk = false;
                        OKText.SetActive(false);
                        selectOkText.SetActive(false);
                        gamePauseText.SetActive(true);
                        selectText.SetActive(true);
                    }


                }
                else
                {
                    //�Z���N�g��ʂɖ߂�
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                    {
                        isOk = true;
                        OKText.SetActive(true);
                        selectOkText.SetActive(true);
                        gamePauseText.SetActive(false);
                        selectText.SetActive(false);
                    }
                }

            }
        }
       

        //�Q�[���N���A���Ĉ��ȏソ������V�[���J��
        if (shater.closeTimer >= 180 && isBuck)
        {

            SceneManager.LoadScene("SelectScene");
        }

    }
}
