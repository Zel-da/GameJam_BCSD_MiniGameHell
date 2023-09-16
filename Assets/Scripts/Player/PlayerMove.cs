using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    public float delayTime = 0.3f;

    bool toLeft = false;
    bool toRight = false;

    private void Awake()
    {
        Vector3 moveVelocity = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") < 0) {
            toLeft = true;
            toRight = false;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0) {
            toLeft = false;
            toRight = true;

        }

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
        // �� �� �Ǵ� ���̵� �ݶ��̴��� �ε����� ���� ����
        if (other.gameObject.CompareTag("obstacle"))
        {
            Time.timeScale = 0;
        }

        // ���� ���� �ݶ��̴��� �ε����� ���� ����
        if (other.gameObject.CompareTag("ScoreUp"))
        {
            Debug.Log("Score Up!");
        }
    }
}

