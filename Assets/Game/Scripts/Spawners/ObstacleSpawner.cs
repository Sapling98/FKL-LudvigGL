using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] hyllaPrefabs;

    [Header("Spawnrate")]
    [SerializeField] private float spawnRate = 2;
    private float timer = 0;

    [Header("Spawn Pos Reference")]
    [SerializeField] private Transform spawnPoint;

    [Header("SpawnPos")]
    [SerializeField] private float depthOffset = 7;

    private float moveSpeed;


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

        GameObject selectedPrefab = hyllaPrefabs[Random.Range(0, hyllaPrefabs.Length)];

        Instantiate(selectedPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * GameManager.instance.GeneralSpeed * Time.deltaTime);
    }
}
