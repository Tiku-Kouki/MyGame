using UnityEngine;
//�S�[���̃X�N���v�g


public class GoalScript : MonoBehaviour
{
    //�Q�[���N���A�̃e�L�X�g
    public GameObject GameClearText;
    //�S�[���̃h�A�ɐG��Ă���Ƃ��\���̃e�L�X�g
    public GameObject DoorInText;
    //�@�N���A�������̕ϐ�
    public static bool isGameClear = false;
    //�@�S�[��������̉�
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
            //�S�[��������e�L�X�g������
            DoorInText.SetActive(false);
            return;
        }

        if (GameManagerScript.eraseGoalText)
        {
            GameClearText.SetActive(false);
        }


    }

    //�G��Ă��鎞
    private void OnCollisionStay(Collision other)
    {
        //�@�R���g���[���̏㉺����
        float moveY = Input.GetAxis("Vertical");

        // �v���C���[���S�[���ɐG��Ă���Ƃ�
        if (other.gameObject.CompareTag("Player"))
        {
            //�e�L�X�g�\��
            DoorInText.SetActive(true);

            //�@����͂�������
            if ((Input.GetKey(KeyCode.UpArrow)||
                moveY >0)&&
                !isGameClear)
            {
                //�S�[������
                goalAudio.Play();
                GameClearText.SetActive(true);
                isGameClear = true;
            }
        }
    }
    //���ꂽ��
    private void OnCollisionExit(Collision other)
    {
        // �v���C���[���S�[�����痣�ꂽ��
        if (other.gameObject.CompareTag("Player"))
        {
            DoorInText.SetActive(false);
        }
    }




}
