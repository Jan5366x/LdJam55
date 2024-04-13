using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemiesToSpawn;
    public int secondsUntilLastEnemy;

    public GameObject enemyTemplate;
    public Transform enemyContainer;
    // public GameObject entityGraveyard;

    private int _enemiesSpawned;
    private float _accumulatedtime;
    private float _timeSinceLastSpawned;
    private float _secondsPerEnemy
    {
        get => (float)secondsUntilLastEnemy / enemiesToSpawn;
    }

    void Start()
    {
    }

    void Update()
    {
        _accumulatedtime += Time.deltaTime;
        if (ShouldSpawnEnemy())
        {
            GameObject enemy = Instantiate(enemyTemplate, enemyContainer);
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            _enemiesSpawned += 1;
            _accumulatedtime = 0;
        }
    }

    private bool ShouldSpawnEnemy()
    {
        bool stillEnemiesToSpawn = _enemiesSpawned < enemiesToSpawn;
        bool hasEnoughTimeExpired = _accumulatedtime > _secondsPerEnemy;
        return stillEnemiesToSpawn && hasEnoughTimeExpired;
    }
}
