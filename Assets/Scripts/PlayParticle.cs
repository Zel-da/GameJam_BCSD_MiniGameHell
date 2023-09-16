using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Transform spawnPosition;

    void Start()
    {
        SpawnAndDeactivatePrefabAfterDelay(1.0f);
    }

    public void SpawnAndDeactivatePrefabAfterDelay(float delay)
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition.position, spawnPosition.rotation);

        Invoke("DeactivatePrefab", delay);
    }

    private void DeactivatePrefab()
    {
        prefabToSpawn.SetActive(false);
    }
}