using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //���߂̂x�̈ʒu
    float fastY;
    //�@�ォ���ǂ����Ɉړ���
    public bool upOrDown = true;
    //�J������̍ŏI�ʒu
    public float openY;
    //�J����X�s�[�h
    float speed = 1.0f;
    //�@�����Ă��邩�ǂ���
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        fastY = transform.position.y;

        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Up
        if (upOrDown)
        {
            if (isOpen && transform.position.y < openY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (isOpen && transform.position.y > fastY)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;

            }
        }
        //Down
        else if(!upOrDown)
        {
            if (isOpen && transform.position.y > openY)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
            else if (isOpen && transform.position.y < fastY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;

            }
        }
        

    }
}
