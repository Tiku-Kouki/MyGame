using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stage�̃J�����̓���


public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private float purasePos = 0;

    private float purasePosZ = 0;


    // Start is called before the first frame update
    void Start()
    {
        purasePos = 0;
        purasePosZ = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if (purasePosZ > -10&& ShaterScript.isUp)
        {
            purasePosZ -= 0.1f;
        }
        if (purasePos < 2 && purasePosZ < -5)
        {
            purasePos += 0.1f;
        }

        //�@�v���C���[�̈ʒu
        var playerPosition = player.transform.position;
        //�@�J�����̈ʒu
        var position = transform.position;



        //�J�������v���C���[�ɒǏ]
        position.x = playerPosition.x;
        if(playerPosition.y > -5)
        {
            position.y = playerPosition.y + purasePos;
        }

        position.z = purasePosZ;

        transform.position = position;

    }
}
