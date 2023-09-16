using UnityEngine;
using System.Collections;


public class RollingObject : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // 오브젝트의 회전 속도
    public float rollSpeed = 5.0f; // 오브젝트의 굴러가는 속도
    public float destroyDelay = 3.0f; // 파괴까지의 대기 시간 (3초)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = rotationSpeed; // 오브젝트를 시계 방향으로 회전
        rb.velocity = new Vector2(rollSpeed, 0); // 오른쪽으로 굴러가는 속도 설정
        StartCoroutine(DestroySelf());
    }
    

    IEnumerator DestroySelf()
    {
        // destroyDelay 시간 동안 대기
        yield return new WaitForSeconds(destroyDelay);

        // 자신의 게임 오브젝트를 파괴
        Destroy(gameObject);
    }
}

