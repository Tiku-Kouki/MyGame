using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WindMoveScript : MonoBehaviour
{
    [SerializeField]
    private float windPowerX = 0f;
    [SerializeField]
    private float windPowerY = 0f;
    [SerializeField]
    private float windPowerZ = 0f;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<Rigidbody>().AddForce(windPowerX, windPowerY, windPowerZ, ForceMode.Impulse);
        }
    }



}
