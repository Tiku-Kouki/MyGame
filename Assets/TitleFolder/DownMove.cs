using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �^�C�g���̉��̃g�Q�̓���

public class DownMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�g���̉��̃g�Q�̈ʒu
        var pos = transform.position;

        pos.x += 0.05f;

        // ���ȏ�ړ����������[�v����
        if (pos.x >= 20.5f)
        {
            pos.x = -20.5f;
        }

        transform.position = pos;
    }
}
