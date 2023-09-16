using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;

    bool toLeft = false;
    bool toRight = false;

    bool isPass = true;
    bool canMove = true;

    public ParticleSystem particle;
    Vector3 moveVelocity = Vector3.zero;
    public GameObject A;
    public GameObject targetObject; // ?? ??? ?? ????

    private void Awake()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        moveVelocity = Vector3.left;
    }

    void Update()
    {
        if (isPass)
            keyActivate(); // ?????? ??????
        
        if (canMove)
            Move(); // ???? ????
    }

    void keyActivate()
    {
        // ?????? ????
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
        if (other.gameObject.CompareTag("obstacle"))
        {
            Time.timeScale = 0;
            A.SetActive(true);
        }

        if (other.gameObject.CompareTag("ScoreUp") || other.gameObject.CompareTag("Tree"))
        {
            isPass = true; // ?????? ??????
            Debug.Log("Score Up!"); // ???? ????
        }

        // ???? ?????????? ??????
        if (other.gameObject.CompareTag("Tree"))
        {
            targetObject.GetComponent<ScoreManager>().score += 10;
        }
    }

    public string targetTag = "Tree"; // 특정 태그
    public GameObject particlePrefab; // 파티클 프리팹

    private int collisionCount = 0; // 충돌 횟수

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collisionCount++;

            // 특정 태그의 오브젝트에 10번 연속 접촉했을 때
            if (collisionCount >= 10)
            {
                // 파티클을 생성하여 재생
                if (particlePrefab != null)
                {
                    Instantiate(particlePrefab, transform.position, Quaternion.identity);
                }

                // 충돌 횟수 초기화
                collisionCount = 0;
            }
        }
    }
}

