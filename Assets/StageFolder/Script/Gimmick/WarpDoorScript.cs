using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WarpDoorScript : MonoBehaviour
{
    //�ړ��ꏊ
    public Vector3 pos;
    //�@�h�A�ɓ�����͂̕\��
    public GameObject DoorInText;
    //�@�ړ�������̃p�[�e�B�N��
    public GameObject bombParticle;

    public AudioSource warpAudio;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    //�G��Ă���Ƃ�
    private void OnCollisionStay(Collision other)
    {
        float moveY = Input.GetAxis("Vertical");

        if (other.gameObject.CompareTag("Player"))
        {
            DoorInText.SetActive(true);

            if (Input.GetKey(KeyCode.UpArrow)||
                moveY >0)
            {
                warpAudio.Play();
                //�@�w��ʒu�Ɉړ�
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
                //�ړ������ꏊ�Ƀp�[�e�B�N��
                Instantiate(bombParticle, pos, Quaternion.identity);

            }

        }
    }

    //���ꂽ��
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�@DoorInText���\���ɂ���
            DoorInText.SetActive(false);
            
        }
    }



}
