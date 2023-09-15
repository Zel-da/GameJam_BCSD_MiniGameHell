using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;//생성할발판의원본프리맵
    public int count = 3;
    public float timeBetSpawnMin = 2f;
    public float timeBetSpawnMax = 2.5f;
    private float timeBetSpawn;
    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;
    private GameObject[] platforms;
    private int currentIndex = 0;
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
