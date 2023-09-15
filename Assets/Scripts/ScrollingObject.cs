using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
