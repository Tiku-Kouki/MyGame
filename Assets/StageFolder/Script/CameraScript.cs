using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stage�̃J�����̓���


public class CameraScript : MonoBehaviour
{
    public GameObject player;

    const int purasePos = 2;

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
        if(playerPosition.y > -5)
        {
            position.y = playerPosition.y + purasePos;
        } 
       
        
        transform.position = position;

    }
}
