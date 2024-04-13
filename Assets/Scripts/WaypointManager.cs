using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update

    private List<Waypoint> _waypoints;
    private Dictionary<Waypoint, Waypoint> _nextPoints = new();

    public Waypoint spawnPoint;
    public Waypoint destinationPoint;

    public void Start()
    {
        _waypoints = new List<Waypoint>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _waypoints.Add(transform.GetChild(i).GetComponent<Waypoint>());
        }

        _nextPoints.Clear();
        spawnPoint = _waypoints[0];
        destinationPoint = _waypoints[^1];
        foreach ((Waypoint left, Waypoint right) in _waypoints.Zip(_waypoints.Skip(1), (x, y) => (x, y)))
        {
            Debug.DrawLine(left.transform.position, right.transform.position);
            _nextPoints.Add(left, right);
        }

        _nextPoints.Add(destinationPoint, destinationPoint);
    }

    private void OnDrawGizmos()
    {
        if (!_nextPoints.Any())
        {
            Start();
        }
        try
        {
            foreach (KeyValuePair<Waypoint, Waypoint> x in _nextPoints)
            {
                Gizmos.DrawLine(x.Key.transform.position, x.Value.transform.position);
            }
        }
        catch (MissingReferenceException)
        {
            Start();
        }
    }

    public Waypoint GetSpawnNode()
    {
        return _waypoints.First();
    }

    public Waypoint GetNextNode(Waypoint current)
    {
        return _nextPoints[current];
    }
}
