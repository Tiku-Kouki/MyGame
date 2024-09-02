using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    
    float speed = 0.5f;

    bool active;

    public AudioSource switchAudio;

    Vector3 startPos;

    float afterPosY;

    public DoorScript door;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        afterPosY = startPos.y - 0.1f;
    }

    

    void Update()
    {
        if (active && transform.position.y > afterPosY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;


            if(transform.position.y <= afterPosY)
            {
                door.isOpen = true;

                enabled = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active && other.CompareTag("Player"))
        {
            switchAudio.Play();
            active = true;

            
        }
    }
}
