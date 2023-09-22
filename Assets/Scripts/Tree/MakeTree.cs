using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    public GameObject tree;
    public float spawnInterval = 1.5f;
    public float initialMovementSpeed = 1.0f;
    public float movementSpeedIncreaseRate = 0.3f;

    private float timer;
    private float movementSpeed;

    void Start()
    {
        movementSpeed = initialMovementSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GameObject newTree = Instantiate(tree);
            float randomX = Random.Range(-5.7f, 5.7f);
            newTree.transform.position = new Vector3(randomX, -6, 0);
            Destroy(newTree, 6.0f);

            timer = 0;
        }

        foreach (GameObject existingTree in GameObject.FindGameObjectsWithTag("TreeObject"))
        {
            existingTree.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

            // ��� ������
            if (existingTree.transform.position.x < -6.7f || existingTree.transform.position.x > 6.7f)
            {
                // ���� �ٲٱ�
                movementSpeed *= -1.0f;
            }
        }

        // ������ �¿� �̵� �ӵ� ����
        movementSpeed += movementSpeedIncreaseRate * Time.deltaTime;
    }
}