using UnityEngine;

public class RotateInPlace1 : MonoBehaviour
{
    public float rotationSpeed = -60.0f; // 회전 속도 (초당 각도)
    public float moveSpeed = 0.0f; // 이동 속도

    void Update()
    {
        // 스페이스바 입력 감지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 스페이스바를 누를 때 오브젝트 회전 방향의 반대로 이동
            Vector3 moveDirection = -transform.up;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        // 오브젝트를 시계방향으로 회전
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}

