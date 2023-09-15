using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 startPos;
    private float repeatHeight;

    [SerializeField] BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatHeight = col.size.y / 2; // ��� ������ ���� ũ��
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (transform.position.y < startPos.y - repeatHeight) // ���� ��ġ�� ���� ��ġ�� ���� Ư�� ������ �����ϸ�
        {
            transform.position = startPos;
        }
    }
}