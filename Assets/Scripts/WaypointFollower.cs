using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public WaypointManager waypointManager;
    public float speed;

    private Waypoint _currentWaypoint = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_currentWaypoint is null)
            _currentWaypoint = waypointManager.spawnPoint;

    }

    private void FixedUpdate()
    {
        if (_currentWaypoint is null)
            return;
        Vector3 currentPos = transform.position;
        Vector3 waypointPos = _currentWaypoint.transform.position;
        Vector3 direction = (waypointPos - currentPos).normalized;
        Vector3 movingToPos = currentPos + direction * (Time.deltaTime * speed);
        if (Vector3.Distance(currentPos, movingToPos) <
            Vector3.Distance(currentPos, waypointPos))
        {
            transform.position = movingToPos;
        }
        else
        {
            transform.position = waypointPos;
        }

        if (transform.position == _currentWaypoint.transform.position)
        {
            if (waypointManager.IsLastNode(_currentWaypoint))
            {
                var power = transform.GetComponent<EntityWithAttack>().attackPower;
                GameObject.Find("GameStateManager").GetComponent<GameStateManager>().AddDamage(power);
                Destroy(gameObject);
            }
            else
            {
                _currentWaypoint = waypointManager.GetNextNode(_currentWaypoint);
            }
        }
    }
}
