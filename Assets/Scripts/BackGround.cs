using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private MeshRenderer render;
    public float speed;
    private float offset;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        // 10초마다 IncreaseSpeed 함수를 호출합니다.
        InvokeRepeating("IncreaseSpeed", 10f, 10f);
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }

    void IncreaseSpeed()
    {
        // speed를 0.1씩 증가시킵니다.
        speed += 0.05f;
    }
}