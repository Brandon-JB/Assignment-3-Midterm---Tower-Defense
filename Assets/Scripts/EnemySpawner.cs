using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    public float timeToSpawn;
    private float timeBetweenSpawns;
    public GameObject normalEnemy;
    public Transform spawnLocation;

    [Header("BombSpawning")]
    public GameObject bombEnemy;
    public float timeToBombSpawn;
    private float timeBetweenBombSpawn;

    [Header("Difficulty Increase")]
    private float timePassed;
    public float timeToIncreaseSpawns;
    public float spawnTimeDecrease = 1;
    public bool WasDifficultyIncreased;

    private void Start()
    {
        timeBetweenSpawns = 0;
        timePassed = 0;
        WasDifficultyIncreased = false;
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        timeBetweenSpawns += Time.deltaTime;
        timeBetweenBombSpawn += Time.deltaTime;

        if (timeBetweenSpawns >= timeToSpawn)
        {
        Instantiate(normalEnemy, spawnLocation.position, spawnLocation.rotation);
        timeBetweenSpawns = 0;
        }

        if (timeBetweenBombSpawn >= timeToBombSpawn)
        {
        Instantiate(bombEnemy, spawnLocation.position, spawnLocation.rotation);
        timeBetweenBombSpawn = 0;
        }

        if (timePassed >= timeToIncreaseSpawns && WasDifficultyIncreased == false)
        {
            timeToSpawn /= spawnTimeDecrease;
            timeToBombSpawn /= spawnTimeDecrease;
            WasDifficultyIncreased = true;
        }
    }
}
