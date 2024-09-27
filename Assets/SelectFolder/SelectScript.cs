using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectScript : MonoBehaviour
{
    public GameObject StageText;

    public string scene;

    public ShaterScript shater;

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
        if(isCollison&& shater.closeTimer >= 360)
        {
            
            SceneManager.LoadScene(scene);
        }




        if ( (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown("joystick button 0"))&&
                isCollison)
        {
            selectAudio.Play();
            StageText.SetActive(false);
            ShaterScript.isShaterOpen = false;
        }


        
    }

    

    

}
