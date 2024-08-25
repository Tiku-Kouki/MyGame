using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GoalScript : MonoBehaviour
{
    public GameObject GameClearText;

    public static bool isGameClear = false;

    

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GameClearText.SetActive(true);
                isGameClear = true;
            }
        }
    }
    





}
