using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트들

    public float moveSpeed = 5.0f; // 이동 속도
    private Rigidbody2D rb;

    public bool isTouchTop;
    public bool isTouchBottom;

    private bool isPaused = false;

    private ScoreManager scoreManager;

    public GameObject objectToDisable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if(!isPaused)
        {
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(0, verticalInput);

            if (isTouchBottom || isTouchTop)
            {
                // 아래로 튕기거나 위로 튕기는 힘을 가하고, 방향을 반대로 설정
                float bounceForce = 10.0f; // 튕기는 힘의 크기 조절
                Vector2 bounceDirection = isTouchBottom ? Vector2.up : Vector2.down;
                rb.velocity = bounceDirection * bounceForce;
            }
            else
            {
                rb.velocity = movement * moveSpeed;
            }
        }else
        {
            StartCoroutine(PauseAfterDelay(2.0f));
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    isTouchBottom = false; // 다른 방향과 충돌 시 반대 방향의 플래그를 해제
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    isTouchTop = false; // 다른 방향과 충돌 시 반대 방향의 플래그를 해제
                    break;
            }
        }

        if (collision.gameObject.tag == "Hit")
        {
            objectToDisable.SetActive(false);
            isPaused = true;
            Debug.Log("GameOver!");
            if (scoreManager != null)
            {
                scoreManager.StopScore(); // 점수 증가 중지
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            // 충돌 영역을 떠나면 플래그를 초기화
            isTouchTop = false;
            isTouchBottom = false;
        }
    }

    void Pause()
    {
        Time.timeScale = 0; // 게임 시간을 멈춤

        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(isPaused);
        }
    }

    IEnumerator PauseAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // 지정한 시간(0.5초) 동안 대기

        Pause(); // 일정 시간 후에 게임 일시 정지
    }

}
