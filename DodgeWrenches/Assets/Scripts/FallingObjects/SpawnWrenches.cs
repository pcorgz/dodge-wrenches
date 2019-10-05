using System.Collections;
using UnityEngine;

public class SpawnWrenches : MonoBehaviour
{
    [SerializeField]
    private float secondsToStart = 5;
    [SerializeField]
    private float minTimeToSpawn = 2f;
    [SerializeField]
    private float maxTimeToSpawn = 5f;
    [SerializeField]
    private GameObject wrenchPrefab = null;

    private bool startSpawning;
    private float timeUntilNextSpawn;
    private float spawnTimer;

    private void Start()
    {
        startSpawning = false;
        spawnTimer = 0;
        StartCoroutine(WaitTimeToStart());
    }

    private void Update()
    {
        if (startSpawning == false || GameManager.isGameOver) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= timeUntilNextSpawn)
        {
            SpawnWrench();
        }
    }

    private void SetSpawnTime()
    {
        timeUntilNextSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
    }

    private IEnumerator WaitTimeToStart()
    {
        yield return new WaitForSecondsRealtime(secondsToStart);
        startSpawning = true;
    }

    private void SpawnWrench()
    {
        SetSpawnTime();
        spawnTimer = 0;
        Instantiate(wrenchPrefab, transform.position, Random.rotationUniform);
    }
}
