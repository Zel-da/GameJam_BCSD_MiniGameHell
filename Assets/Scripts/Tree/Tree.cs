using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] Collider2D obstacleCol;
    [SerializeField] Collider2D obstacleCol2;
    [SerializeField] Collider2D scoreUpCol;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(obstacleCol); // 양 옆 콜라이더 삭제
            Destroy(obstacleCol2);
            Destroy(scoreUpCol); // 스코어업 콜라이더 삭제
            Destroy(gameObject); // 나무 삭제
        }
    }
}
