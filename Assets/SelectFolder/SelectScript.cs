using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//�Z���N�g�X�e�[�W�̃X�N���v�g

public class SelectScript : MonoBehaviour
{
    //�ǂ̃X�e�[�W���̃X�e�[�W�̃e�L�X�g
    public GameObject stageText;
    //�ړ�����scene
    public string scene;
    //��ʈړ��̃V���b�^�[
    public ShaterScript shater;
    //�������Ă��邩�ǂ���
    bool isCollison = false;
    //���肵���Ƃ��̉�
    public AudioSource selectAudio;

    //�G��Ă���Ƃ�
    private void OnCollisionStay(Collision other)
    {
         if (other.gameObject.CompareTag("Player"))
        {

            //�V���b�^�[���J���Ă��邩�ŕ\���ύX
            if (ShaterScript.isShaterOpen)
            {
                stageText.SetActive(true);
            }
            else
            {
                stageText.SetActive(false);
            }
            isCollison = true;
        }
    }
    /// ���ꂽ��
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //��\���ɂ���
                stageText.SetActive(false);
            
            
            isCollison = false;
        }
    }

    private void Update()
    {
        //isCollison��true�ň�莞�Ԃ�������LoadScene
        if (isCollison&& shater.closeTimer >= 180)
        {
            
            SceneManager.LoadScene(scene);
        }



        //�X�e�[�W����ƃV���b�^�[������
        if ( (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown("joystick button 0"))&&
                isCollison)
        {
            selectAudio.Play();
            stageText.SetActive(false);
            ShaterScript.isShaterOpen = false;
        }


        
    }

    

    

}
