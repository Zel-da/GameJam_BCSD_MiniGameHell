using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIcon : MonoBehaviour
{

    public float rotationSpeed = 30.0f; // 회전 속도 (초당 각도)

    void Update()
    {
        // 오브젝트를 시계방향으로 회전
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
 