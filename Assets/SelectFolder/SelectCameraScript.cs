using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�Z���N�g��ʂ̃J�����̓���

public class SelectCameraScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    

    // Update is called once per frame
    void Update()
    {
        //�@�v���C���[�̈ʒu
        var playerPosition = player.transform.position;
        //�@�J�����̈ʒu
        var position = transform.position;
        //�J�������v���C���[�ɒǏ]
        position.x = playerPosition.x;
        position.y = playerPosition.y +1;
         position.z = playerPosition.z - 5;
        transform.position = position;

    }
}
