using UnityEngine;
//ゴールのスクリプト


public class GoalScript : MonoBehaviour
{
    //ゲームクリアのテキスト
    public GameObject GameClearText;
    //ゴールのドアに触れているとき表示のテキスト
    public GameObject DoorInText;
    //　クリアしたかの変数
    public static bool isGameClear = false;
    //　ゴールした後の音
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
            //ゴールした後テキストを消す
            DoorInText.SetActive(false);
            return;
        }

        if (GameManagerScript.eraseGoalText)
        {
            GameClearText.SetActive(false);
        }


    }

    //触れている時
    private void OnCollisionStay(Collision other)
    {
        //　コントローラの上下入力
        float moveY = Input.GetAxis("Vertical");

        // プレイヤーがゴールに触れているとき
        if (other.gameObject.CompareTag("Player"))
        {
            //テキスト表示
            DoorInText.SetActive(true);

            //　上入力をしたら
            if ((Input.GetKey(KeyCode.UpArrow)||
                moveY >0)&&
                !isGameClear)
            {
                //ゴール判定
                goalAudio.Play();
                GameClearText.SetActive(true);
                isGameClear = true;
            }
        }
    }
    //離れた時
    private void OnCollisionExit(Collision other)
    {
        // プレイヤーがゴールから離れた時
        if (other.gameObject.CompareTag("Player"))
        {
            DoorInText.SetActive(false);
        }
    }




}
