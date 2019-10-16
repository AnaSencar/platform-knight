using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject persistantObjectsPrefab;
    static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned)
        {
            return;
        }
        SpawnPersistantPrefabs();
        hasSpawned = true;
    }

    private void SpawnPersistantPrefabs()
    {
        GameObject persistantObject = Instantiate(persistantObjectsPrefab);
        DontDestroyOnLoad(persistantObject);
    }

}
