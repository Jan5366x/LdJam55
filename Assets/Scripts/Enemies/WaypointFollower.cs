using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public WaypointManager waypointManager;
    public float speed;

    private Waypoint _currentWaypoint = null;

    public Vector3 CurrentDirection { get; set; }
    public float CurrentSpeed { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (_currentWaypoint == null)
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
        CurrentDirection = direction;
        if (Vector3.Distance(currentPos, movingToPos) <
            Vector3.Distance(currentPos, waypointPos))
        {
            transform.position = movingToPos;
        }
        else
        {
            transform.position = waypointPos;
        }

        CurrentSpeed = Vector3.Distance(transform.position, currentPos);

        if (transform.position == _currentWaypoint.transform.position)
        {
            if (waypointManager.IsLastNode(_currentWaypoint))
            {
                transform.GetComponent<EntityWithAttack>().AttackCastle();
                Destroy(gameObject);
            }
            else
            {
                _currentWaypoint = waypointManager.GetNextNode(_currentWaypoint);
            }
        }
    }
}
