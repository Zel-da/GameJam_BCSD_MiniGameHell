using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    public float delayTime = 0.3f;

    bool toLeft = false;
    bool toRight = false;

    bool isPass = true;
    bool canMove = true;

    private void Awake()
    {
        Vector3 moveVelocity = Vector3.zero;
    }

    void Update()
    {
        if (isPass)
            keyActivate(); // 방향키 활성화
        
        if (canMove)
            Move(); // 이동 가능
    }

    void keyActivate()
    {
        // 방향키 입력
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            toLeft = true;
            toRight = false;
            isPass = false;
            canMove = true;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            toLeft = false;
            toRight = true;
            isPass = false;
            canMove = true;
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (toLeft) {
            transform.localScale = new Vector3(-1, 1, 1);
            moveVelocity = Vector3.left;
        }

        else if (toRight) {
            transform.localScale = new Vector3(1, 1, 1);
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // 양 옆 또는 사이드 콜라이더와 충돌시
        if (other.gameObject.CompareTag("obstacle"))
        {
            Time.timeScale = 0; // 게임 종료
        }

        // 나무 사이 콜라이더와 충돌시
        if (other.gameObject.CompareTag("ScoreUp") || other.gameObject.CompareTag("Tree"))
        {
            isPass = true; // 방향키 활성화
            Debug.Log("Score Up!"); // 점수 증가
        }
    }
}

