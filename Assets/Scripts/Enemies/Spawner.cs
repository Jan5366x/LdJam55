using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemiesToSpawn;
    public int secondsUntilLastEnemy;

    public GameObject enemyTemplate;
    public Transform enemyContainer;

    public WaypointManager waypointManager;

    public AnimationCurve curve = AnimationCurve.Linear(0,0,10,10);

    public bool overwriteSpeed;
    public float speed;

    public bool overwriteDamage;
    public int damage;

    public bool overwriteHealth;
    public int health;

    // public GameObject entityGraveyard;

    private int _enemiesSpawned;
    private float _accumulatedtime;
    private float _accumulatedtimeAll;

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
        _accumulatedtimeAll += Time.deltaTime;
        if (ShouldSpawnEnemy())
        {
            GameObject enemy = Instantiate(enemyTemplate, enemyContainer);
            var waypointFollower = enemyTemplate.GetComponent<WaypointFollower>();
            waypointFollower.waypointManager = waypointManager;
            var healthComponent = enemyTemplate.GetComponent<EntityWithHealth>();
            var attacker = enemyTemplate.GetComponent<EntityWithAttack>();
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            if (overwriteSpeed)
                waypointFollower.speed = speed;
            if (overwriteDamage)
                attacker.attackPower = damage;
            if (overwriteHealth)
                healthComponent.health = health;
            _enemiesSpawned += 1;
            _accumulatedtime = 0;
        }
    }

    private bool ShouldSpawnEnemy()
    {
        float fullArea = IntegrateCurve(curve, 0, 1, 100);
        float currentArea = IntegrateCurve(curve, 0, _accumulatedtimeAll / secondsUntilLastEnemy, 100);
        float toSpawn = currentArea / fullArea * enemiesToSpawn;
        toSpawn = toSpawn >= enemiesToSpawn ? enemiesToSpawn : toSpawn;
        bool stillEnemiesToSpawn = _enemiesSpawned < enemiesToSpawn;
        // bool hasEnoughTimeExpired = _accumulatedtime > _secondsPerEnemy;
        bool hasEnoughTimeExpired = _enemiesSpawned < toSpawn;
        return stillEnemiesToSpawn && hasEnoughTimeExpired;
    }

    // https://discussions.unity.com/t/calculate-surface-under-a-curve-from-an-animationcurve/175312/2
    /// <summary>
    /// Integrate area under AnimationCurve between start and end time
    /// </summary>
    /// <param name="curve"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="steps"></param>
    /// <returns></returns>
    private static float IntegrateCurve(AnimationCurve curve, float startTime, float endTime, int steps)
    {
        return Integrate(curve.Evaluate, startTime, endTime, steps);
    }

    /// <summary>
    /// Integrate function f(x) using the trapezoidal rule between x=xLow..xHigh
    /// </summary>
    /// <param name="f"></param>
    /// <param name="xLow"></param>
    /// <param name="xHigh"></param>
    /// <param name="nSteps"></param>
    /// <returns></returns>
    private static float Integrate(Func<float, float> f, float xLow, float xHigh, int nSteps)
    {
        float h = (xHigh - xLow) / nSteps;
        float res = (f(xLow) + f(xHigh)) / 2;
        for (int i = 1; i < nSteps; i++)
        {
            res += f(xLow + i * h);
        }
        return h * res;
    }
}