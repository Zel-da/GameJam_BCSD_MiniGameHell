using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 랜덤하게 생성할 오브젝트들을 할당
    public float spawnInterval = 2.0f; // 생성 간격 (예: 2초마다)

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnRandomObject();
            timeSinceLastSpawn = 0.0f;
        }
    }

    void SpawnRandomObject()
    {
        if (objectPrefabs.Length == 0)
        {
            Debug.LogError("No object prefabs assigned!");
            return;
        }

        // 랜덤하게 오브젝트를 선택
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        // 선택한 프리팹의 위치 정보를 가져옴
        Vector3 spawnPosition = selectedPrefab.transform.position;

        // 오브젝트 생성
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
