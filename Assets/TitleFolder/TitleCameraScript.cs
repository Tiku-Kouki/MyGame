using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�^�C�g���̃J����


public class TitleCameraScript : MonoBehaviour
{
    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�J�����̌Œ�
        var titlePosition = title.transform.position;
        var position = transform.position;
        position.x = titlePosition.x;
        position.y = titlePosition.y;
        transform.position = position;

    }
}
