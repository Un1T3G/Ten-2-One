using System.Collections;
using System.Collections.Generic;
using Un1T3G.Pool;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private GameObject _cubePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnCube();
    }

    private void SpawnCube()
    {
        var position = Random.insideUnitSphere * _spawnRadius;
        PoolManager.Spawn(_cubePrefab, position, Quaternion.identity, transform);
    }
}
