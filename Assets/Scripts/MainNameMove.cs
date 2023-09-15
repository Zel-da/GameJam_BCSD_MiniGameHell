using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainNameMove : MonoBehaviour
{
    Vector3 pos;
    public float delta = 2.0f;
    public float speed = 3.0f;

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
