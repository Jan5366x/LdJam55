using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponent<WaypointManager>().Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Index()
    {
        return transform.GetSiblingIndex();
    }
}
