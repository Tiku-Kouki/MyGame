using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ShaterScript : MonoBehaviour
{
    //�V���b�^�[�̃I�u�W�F�N�g
    public GameObject shater;
    //�V���b�^�[���J���Ă��邩
    public  static bool isShaterOpen = true;
    //���܂������Ԍo��
    public int closeTimer = 0;
    //�J�̃X�s�[�h
    [SerializeField]
    float speed = 0.01f;
    //�Œ�ʒu
    [SerializeField]
    float downPos;
    //�ő�ʒu
    [SerializeField]
    float upPos;

    public static bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        isShaterOpen = true;
        closeTimer = 0;

        shater.gameObject.GetComponent<Image>().color= new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    void Update()
    {
        // isShaterOpen�̏�Ԃɂ���Ċ֐���
        // �Ăяo�����
        if (isShaterOpen)
        {
            UpPosition();
        }
        else
        if (!isShaterOpen)
        {
            DownPosition();

            closeTimer += 1;
        }
        

    }

    //shater�����
    void DownPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y > downPos)
        {
            pos.y -= speed;

            shater.transform.position = pos;
        }
        else
        {
            shater.transform.position = new Vector3(shater.transform.position.x, downPos, shater.transform.position.z);

        }



    }

    //shater���J��
    void UpPosition()
    {
        var pos = shater.transform.position;

        if ( pos.y < upPos)
        {
            isUp = false;

            pos.y += speed;
            shater.transform.position = pos;

        }else if (pos.y >= upPos)
        {
            shater.transform.position = new Vector3(shater.transform.position.x, upPos, shater.transform.position.z);


            isUp = true;
            

        }
        closeTimer = 0;

    }

}
