using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//スイッチのスクリプト

public class SwitchScript : MonoBehaviour
{
    //沈むスピード
    float speed = 0.5f;
    //　スイッチONであるか
    bool active;

    public AudioSource switchAudio;
    //初めの位置
    Vector3 startPos;
    //最大沈む位置
    float afterPosY;

    float afterMinus = 0.1f;

    //　ドアと連携させる
    public DoorScript door;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        afterPosY = startPos.y - afterMinus;
    }

    

    void Update()
    {
        // activeがtrueの時下に沈む
        if (active && transform.position.y > afterPosY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;

            //一定以上沈んだらdoor.isOpen をtrueにする;
            if (transform.position.y <= afterPosY)
            {
                door.isOpen = true;

                enabled = false;
            }

        }
    }

    // 上から押されたときactiveをtrue
    private void OnTriggerEnter(Collider other)
    {
        if (!active && other.CompareTag("Player"))
        {
            switchAudio.Play();
            active = true;

            
        }
    }
}
