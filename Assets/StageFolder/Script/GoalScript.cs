using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject GameClearText;

    public GameObject DoorInText;

    public static bool isGameClear = false;

    public AudioSource goalAudio;



    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    private void Update()
    {
        if (isGameClear)
        {
           
            DoorInText.SetActive(false);

            return;
        }


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

                goalAudio.Play();
                GameClearText.SetActive(true);
                isGameClear = true;
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
