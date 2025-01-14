using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 20.0f;//�@�W�����v�̃p���[


    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // ���������v���C���[��Rigidbody�R���|�[�l���g���擾���āA��ɗ͂�^����
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.Impulse);

        }

    }


    private void Update()
    {
        


    }

}
