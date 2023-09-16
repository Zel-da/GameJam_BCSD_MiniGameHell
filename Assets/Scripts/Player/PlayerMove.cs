using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public GameObject particle;
    public int passNum = 0;
    int cnt = 0;
    public TMP_Text comboTxt;

    public float movePower = 1f;

    bool isPass = true;
    bool canMove = true;

    int count = 1;

    Vector3 moveVelocity = Vector3.zero;
    public GameObject A;
    public GameObject targetObject;

    private bool isFacingRight = true; // 플레이어가 오른쪽을 보고 있는지 여부

    private void Awake()
    {
        comboTxt.enabled = false;
        particle.SetActive(false);

        // 초기 방향을 오른쪽으로 설정
        isFacingRight = true;
        moveVelocity = Vector3.right;
    }

    void Update()
    {
        if (canMove)
            Move();

        // 스페이스바를 눌렀을 때 좌우를 반전시키는 기능 추가
        if (Input.GetKeyDown(KeyCode.Space) && count > 0 )
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
            moveVelocity = isFacingRight ? Vector3.right : Vector3.left;
            count = 1;
        }
    }

    void Move()
    {
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
            count++;
            cnt++;
            passNum++;
            isPass = true;

            if (passNum == 10)
            {
                comboTxt.text = cnt.ToString();
                if (particle != null)
                {
                    comboTxt.enabled = true;
                    particle.SetActive(true);
                }
                passNum = 0;
            }
            else if ((passNum % 5 == 0))
            {
                particle.SetActive(false);
            }
            else if ((passNum % 3 == 0))
            {
                comboTxt.enabled = false;
            }
        }
    }
}
