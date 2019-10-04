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
    private Transform spawnPoint = null;
    [SerializeField]
    private GameObject wrenchPrefab = null;

    private bool startGame;
    private float timeUntilNextSpawn;
    private float spawnTimer;

    private void Start()
    {
        startGame = false;
        StartCoroutine(WaitTimeToStart());
        spawnTimer = 0;
    }

    private void Update()
    {
        if (startGame == false) return;

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
        startGame = true;
    }

    private void SpawnWrench()
    {
        SetSpawnTime();
        spawnTimer = 0;
        Instantiate(wrenchPrefab, spawnPoint.position, Random.rotationUniform);
    }
}
