using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �^�C�g���̏�̃g�Q�̓���


public class UpMove : MonoBehaviour
{
    private const float loopPoint = 20.5f;
    private const float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�@�^�C�g���̏�̃g�Q�̈ʒu
        var pos = transform.position;

        pos.x -= speed;

        // ���ȏ�ړ����������[�v����
        if (pos.x <= -loopPoint)
        {
            pos.x = loopPoint;
        }

        transform.position = pos;
    }
}
