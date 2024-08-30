using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public GameObject hitKey;

    private int timer = 0;

    public AudioSource hitKeyAudio;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer % 100 > 70)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetButtonDown("Jump"))
        {
            hitKeyAudio.Play();
            SceneManager.LoadScene("SelectScene");
        }
    }
}
