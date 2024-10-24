using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �Z���N�g��ʂ̃v���C���[�ړ�

public class SelectPlayerScript : MonoBehaviour
{
    // �v���C���[��Rigidbody
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��Rigidbody��velocity������
        Vector3 v = rb.velocity;
        //�v���C���[��position������
        var pos = transform.position;

        // x�������̈ړ��͈͐���
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);
        // ���������̈ړ��͈͐���
        pos.z = Mathf.Clamp(pos.z, -5.5f, 5.5f);

        //�v���C���[�̈ړ����x
        float moveSpeed = 5.0f;

       
        //�Q�[���p�b�h�̃X�e�B�b�N���͎󂯎��
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (!ShaterScript.isShaterOpen)
        {
            return;
        }

        //�@�v���C���[�̈ړ�
        if (Input.GetKey(KeyCode.RightArrow)||moveX>0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)|| moveX<0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) || moveY > 0)
        {
            v.z = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.DownArrow) || moveY<0)
        {
            v.z = -moveSpeed;
        }
        else
        {
            v.z = 0;
        }

        rb.velocity = v;
        transform.position = pos;
    }
}
