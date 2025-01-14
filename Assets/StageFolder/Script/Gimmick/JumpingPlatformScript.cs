using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 20.0f;//　ジャンプのパワー


    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // 当たったプレイヤーのRigidbodyコンポーネントを取得して、上に力を与える
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.Impulse);

        }

    }


    private void Update()
    {
        


    }

}
