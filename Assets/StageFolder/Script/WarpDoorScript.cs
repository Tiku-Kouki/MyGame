using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WarpDoorScript : MonoBehaviour
{
    //移動場所
    public Vector3 pos;
    //　ドアに入る入力の表示
    public GameObject DoorInText;
    //　移動した後のパーティクル
    public GameObject bombParticle;

    public AudioSource warpAudio;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    //触れているとき
    private void OnCollisionStay(Collision other)
    {
        float moveY = Input.GetAxis("Vertical");

        if (other.gameObject.CompareTag("Player"))
        {
            DoorInText.SetActive(true);

            if (Input.GetKey(KeyCode.UpArrow)||
                moveY >0)
            {
                warpAudio.Play();
                //　指定位置に移動
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
                //移動した場所にパーティクル
                Instantiate(bombParticle, pos, Quaternion.identity);

            }

        }
    }

    //離れた時
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //　DoorInTextを非表示にする
            DoorInText.SetActive(false);
            
        }
    }



}
