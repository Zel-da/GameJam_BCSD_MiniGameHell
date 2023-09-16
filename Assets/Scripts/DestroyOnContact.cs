using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public string targetTag = "Target"; // 파괴 대상 태그 이름

    // 충돌이 시작될 때 호출됩니다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 특정 태그를 가진 경우
        if (collision.gameObject.CompareTag(targetTag))
        {
            // 충돌한 오브젝트를 파괴합니다.
            Destroy(collision.gameObject);
        }
    }
}
