using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Rigidbody
    public Rigidbody rb;
    //�u���b�N�ɐG��Ă��邩
    private bool isBlock = true;
    //�W�����v������̉�
    public AudioSource jumpAudio;
    //�������̉�
    public AudioSource coinAudio;
    //�W�����v������
    int jumpCount = 0;
    // �ړ��X�s�[�h
    float moveSpeed = 5.0f;
    //�����̈ʒu
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
    }

    
    
    //�G�ꂽ��
    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);

            coinAudio.Play();
            //���_�ɒǉ�
            GameManagerScript.score += 1;

            
        }

        //Ground�̃I�u�W�F�N�g�ɐG�ꂽ��W�����v���Z�b�g
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        


    }

   
    


    // Update is called once per frame
    void Update()
    {
        //�@rb�̈ꎞ�ۑ�
        Vector3 v = rb.velocity;
        //�@position�̈ꎞ�ۑ�
        var pos = transform.position;

       
        
        //�����̈ʒu�m�F�Ɏg�p
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        Ray ray = new Ray(rayPosition, transform.up * -1);

        float distance = 0.35f;

        
        float moveX = Input.GetAxis("Horizontal");

        //RaycastHit hit;
        isBlock = Physics.Raycast(ray, distance);


        // ���ɗ������������ʒu�ɖ߂�
        if (transform.position.y <= -5.0f)
        {
            transform.position = startPos;
            return;
        }

        //isBlock���������Ă邩�ǂ���
        if (isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
            Debug.Log(jumpCount);
        }
        else if
        (!isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }

        //�Q�[���N���A������d��
        if (GoalScript.isGameClear)
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;
            return;
        }

        //�|�[�Y��ʒ��ړ�����
        if(PauseManagerScript.isGamePouse|| !StartScript.isStart) 
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;

            return;
        }

        //�v���C���[�̈ړ�
        if (Input.GetKey(KeyCode.RightArrow) ||
            moveX > 0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)||
            moveX < 0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }
        //�v���C���[2��܂ŃW�����v�\
        if ((Input.GetKeyDown(KeyCode.Space)||
            Input.GetKeyDown("joystick button 0"))
            &&jumpCount<2)
        {
            v.y = 5;


            jumpCount++;

            jumpAudio.Play();

            Debug.Log(jumpCount);

        }

        

        rb.velocity = v;
        transform.position = pos;
    }

    



}
