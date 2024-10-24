using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�X�C�b�`�̃X�N���v�g

public class SwitchScript : MonoBehaviour
{
    //���ރX�s�[�h
    float speed = 0.5f;
    //�@�X�C�b�`ON�ł��邩
    bool active;

    public AudioSource switchAudio;
    //���߂̈ʒu
    Vector3 startPos;
    //�ő咾�ވʒu
    float afterPosY;
    //�@�h�A�ƘA�g������
    public DoorScript door;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        afterPosY = startPos.y - 0.1f;
    }

    

    void Update()
    {
        // active��true�̎����ɒ���
        if (active && transform.position.y > afterPosY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;

            //���ȏ㒾�񂾂�door.isOpen ��true�ɂ���;
            if (transform.position.y <= afterPosY)
            {
                door.isOpen = true;

                enabled = false;
            }

        }
    }

    // �ォ�牟���ꂽ�Ƃ�active��true
    private void OnTriggerEnter(Collider other)
    {
        if (!active && other.CompareTag("Player"))
        {
            switchAudio.Play();
            active = true;

            
        }
    }
}
