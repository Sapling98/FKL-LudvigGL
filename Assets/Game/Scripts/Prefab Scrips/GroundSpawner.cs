using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject Hylla;
    [Header("Spawnrate")]
    [SerializeField] private float spawnRate = 2;
    [SerializeField] private float timer = 0;

    [Header("Spawn Pos Reference")]
    [SerializeField] private Transform spawnPoint;

    [Header("SpawnPos")]
    [SerializeField] private float depthOffset = 7;
    [SerializeField] private float _z;

    [Header("MoveSpeed")]
    [SerializeField] private float moveSpeed;

    void Start()
    {
        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }

        SpawnHylla();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnHylla();
            timer = 0;
        }
        MoveRight();
    }

    private void SpawnHylla()
    {
        float lowestPoint = transform.position.z - depthOffset;
        float highestPoint = transform.position.z + depthOffset;
        Instantiate(Hylla, new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z), transform.rotation);
    }

    void MoveRight()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
    }
}