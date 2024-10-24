using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //初めのＹの位置
    float fastY;
    //　上か下どっちに移動か
    public bool upOrDown = true;
    //開けた後の最終位置
    public float openY;
    //開けるスピード
    float speed = 1.0f;
    //　あいているかどうか
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        fastY = transform.position.y;

        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Up
        if (upOrDown)
        {
            if (isOpen && transform.position.y < openY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (isOpen && transform.position.y > fastY)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;

            }
        }
        //Down
        else if(!upOrDown)
        {
            if (isOpen && transform.position.y > openY)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }
            else if (isOpen && transform.position.y < fastY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;

            }
        }
        

    }
}
