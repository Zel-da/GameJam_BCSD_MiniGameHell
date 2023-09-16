using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] Collider2D obstacleCol;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(obstacleCol); // 양 옆 콜라이더 삭제
            Destroy(gameObject); // 나무 삭제
        }
    }
}
