using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WarpDoorScript : MonoBehaviour
{
    public Vector3 pos;

    public GameObject DoorInText;

    public GameObject bombParticle;

    public AudioSource warpAudio;

    // Start is called before the first frame update
    void Start()
    {
        

    }

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
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
                Instantiate(bombParticle, pos, Quaternion.identity);

            }

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoorInText.SetActive(false);
            
        }
    }



}
