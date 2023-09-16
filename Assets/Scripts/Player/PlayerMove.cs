using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1f;
    private int passNum = 0;

    public GameObject particle;
    public TMP_Text comboTxt;
    private int cnt = 0;

    bool toLeft = false;
    bool toRight = false;

    bool isPass = true;
    bool canMove = true;

    Vector3 moveVelocity = Vector3.zero;

    private void Awake()
    {
        comboTxt.enabled = false;
        particle.SetActive(false);

        transform.localScale = new Vector3(-1, 1, 1);
        moveVelocity = Vector3.left;
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
            cnt++;
            passNum++;
            isPass = true; // 방향키 활성화

            if(passNum == 10)
            {
                comboTxt.text = cnt.ToString();

                if (particle != null)
                {
                    comboTxt.enabled = true;
                    particle.SetActive(true);
                }

                passNum = 0;            
            }

            else if((passNum % 5 == 0))
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

