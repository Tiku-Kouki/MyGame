using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class SelectTitleScript : MonoBehaviour
{
    public GameObject TitleText;



    

    private void OnCollisionStay(Collision other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            TitleText.SetActive(true);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TitleText.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
