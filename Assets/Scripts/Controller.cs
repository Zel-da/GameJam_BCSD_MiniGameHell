
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동 속도
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 위아래 방향키 입력 처리
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 설정
        Vector2 movement = new Vector2(0, verticalInput);

        // Rigidbody2D를 사용하여 움직임 적용
        rb.velocity = movement * moveSpeed;
    }
}
