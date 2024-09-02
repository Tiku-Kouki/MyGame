using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectScript : MonoBehaviour
{
    public GameObject StageText;

    public string scene;

    

    bool isCollison = false;

    public AudioSource selectAudio;

    private void OnCollisionStay(Collision other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            StageText.SetActive(true);

            isCollison = true;
           
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StageText.SetActive(false);
            isCollison = false;
        }
    }

    private void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown("joystick button 0"))&&
                isCollison)
        {
            selectAudio.Play();
            SceneManager.LoadScene(scene);
        }

    }

    

    

}
