using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    [SerializeField] Collider2D obstacleCol;
    [SerializeField] Collider2D obstacleCol2;
    [SerializeField] Collider2D treeCol;
    [SerializeField] Collider2D treeCol2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(obstacleCol); // 양 옆 콜라이더 삭제
            Destroy(obstacleCol2);
            Destroy(treeCol); // 트리 콜라이더 삭제
            Destroy(treeCol2);
        }

        if (other.gameObject.CompareTag("ScoreUp"))
        {
            Score.score += 10;
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            Score.score += 50;
        }
    }
}