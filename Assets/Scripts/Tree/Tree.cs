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
            Destroy(obstacleCol); // �� �� �ݶ��̴� ����
            Destroy(obstacleCol2);
            Destroy(scoreUpCol); // ���ھ�� �ݶ��̴� ����
            Destroy(gameObject); // ���� ����
        }
    }
}
