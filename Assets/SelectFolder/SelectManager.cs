using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public GameObject StageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShaterScript.isUp)
        {
            StageText.SetActive(false);
        }
        else
        {
            StageText.SetActive(true);
        }



    }
}
