using System.Collections;
using UnityEngine;

public class SpawnFallingObjects : MonoBehaviour
{
    [SerializeField]
    private float secondsToStart = 5;
    [SerializeField]
    private float minTimeToSpawn = 2f;
    [SerializeField]
    private float maxTimeToSpawn = 5f;
    [SerializeField]
    private GameObject fallingObjectPrefab = null;
    [SerializeField]
    private bool hasRandomRotation = false;

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
            SpawnNext();
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

    private void SpawnNext()
    {
        SetSpawnTime();
        spawnTimer = 0;

        var randRot = hasRandomRotation
                ? Quaternion.Euler(Random.Range(0, 359), 0f, Random.Range(0, 359))
                : Quaternion.identity;

        Instantiate(
                fallingObjectPrefab,
                transform.position,
                randRot
            );
    }
}
