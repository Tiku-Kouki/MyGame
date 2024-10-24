using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//�^�C�g���̃X�N���v�g

public class TitleScript : MonoBehaviour
{
    //�@A�{�^���������̕\���I�u�W�F�N�g
    public GameObject hitKey;
    // �V���b�^�[
    public ShaterScript shater;
    //�@hitKey�̓_�łɎg�p
    private int timer = 0;
    //�@�X�e�[�W�ړ����Ԃ̐����Ɏg�p
    private int startTimer = 0;
    // ��
    public AudioSource hitKeyAudio;
    //�@�{�^�������������ǂ���
    bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        //�X�N���[���̔䗦�ύX
        Screen.SetResolution(1920, 1080, false);
        timer = 0;
        startTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�V���b�^�[���J���Ă���ԓ_��
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


        //�Ή�����{�^����������isStart��
        //true�ɂ���
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

        //startTimer��160�ȏ�ɂȂ������V�[���J��
        if (startTimer>=160)
        {
            
            SceneManager.LoadScene("SelectScene");
        }


        


    }
}
