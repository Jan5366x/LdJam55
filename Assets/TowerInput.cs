using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerInput : MonoBehaviour
{
    public GameObject towerTemplate;
    public Transform towerContainer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool towerPlaceRequested = Input.GetButtonDown("Fire1");
        if (!towerPlaceRequested)
            return;
        GameObject[] slots = GameObject.FindGameObjectsWithTag("TowerBuildingSlot");
        // TODO: Measure distance to player
        TowerSlot slot = slots
            .OrderBy(x => Vector3.Distance(transform.position, x.transform.position))
            .First()
            .GetComponent<TowerSlot>();
        if (!slot.isOccupied)
        {
            GameObject tower = Instantiate(towerTemplate, slot.transform);
            tower.transform.position = slot.transform.position;
        }
    }
}
