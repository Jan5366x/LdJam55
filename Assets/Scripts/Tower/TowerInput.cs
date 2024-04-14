using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerInput : MonoBehaviour
{
    public GameObject towerTemplate;
    public Transform towerContainer;
    public GameObject player;
    public GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        player = player != null ? player : GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bool towerPlaceRequested = Input.GetButtonDown("Fire1");
        if (!towerPlaceRequested)
            return;
        GameObject[] slots = GameObject.FindGameObjectsWithTag("TowerBuildingSlot");
        GameObject slot = slots
            .OrderBy(x => Vector3.Distance(player.transform.position, x.transform.position))
            .FirstOrDefault();

        if (slot is null)
        {
            // TODO: Handle what happens when no slot was found
            return;
        }

        var towerSlot = slot.GetComponent<TowerSlot>();
        // TODO: Add cost field to tower script
        const int towerCost = 10;
        if (!towerSlot.isOccupied && gameStateManager.GetCurrency() >= towerCost)
        {
            gameStateManager.AddCurrency(-towerCost);
            GameObject tower = Instantiate(towerTemplate, slot.transform);
            tower.transform.position = slot.transform.position;
            towerSlot.isOccupied = true;
        }
    }
}
