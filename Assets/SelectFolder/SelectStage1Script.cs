using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class SelectStage1Script : MonoBehaviour
{
    public GameObject Stage1Text;

    

    

    private void OnCollisionStay(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            Stage1Text.SetActive(true);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Stage1Text.SetActive(false);
        }
    }
   


    
}
