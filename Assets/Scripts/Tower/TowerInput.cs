using System.Linq;
using UnityEngine;

public class TowerInput : MonoBehaviour
{
    public GameObject towerTemplate;
    public GameObject player;
    public GameStateManager gameStateManager;

    public GameObject buildSoundTemplate;
    public GameObject buildingSlotMarker;

    public float buildRadius = 1.5f;
    public int buildCosts = 10;

    private GameObject _nearestBuildingSlot;

    // Start is called before the first frame update
    private void Start()
    {
        player = player != null ? player : GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        var slots = GameObject.FindGameObjectsWithTag("TowerBuildingSlot");
        var newSlot = slots
            .Where(x => Vector3.Distance(player.transform.position, x.transform.position) <= buildRadius &&
                        x.GetComponent<TowerSlot>().isOccupied is false)
            .OrderBy(x => Vector3.Distance(player.transform.position, x.transform.position))
            .FirstOrDefault();

        if (newSlot == _nearestBuildingSlot)
        {
            return;
        }

        _nearestBuildingSlot = newSlot;
        var oldMarkers = GameObject.FindGameObjectsWithTag("BuildingSlotMarker");
        foreach (var marker in oldMarkers)
        {
            Destroy(marker);
        }

        if (newSlot is not null)
        {
            var marker = Instantiate(buildingSlotMarker, newSlot.transform);
            marker.transform.position = newSlot.transform.position;
        }
    }
    
    public void Fired()
    {
        if (_nearestBuildingSlot is null)
        {
            GameObject.Find("Info Text").GetComponent<AutoClearTextfield>().SetText("No Buildslot in range");
            return;
        }

        var towerSlot = _nearestBuildingSlot.GetComponent<TowerSlot>();
        if (!towerSlot.isOccupied && gameStateManager.GetCurrency() >= buildCosts)
        {
            gameStateManager.AddCurrency(-buildCosts);
            GameObject tower = Instantiate(towerTemplate, _nearestBuildingSlot.transform);
            tower.transform.position = _nearestBuildingSlot.transform.position;
            towerSlot.isOccupied = true;
            towerSlot.GetComponentInChildren<SpriteRenderer>().enabled = false;
            
            var buildSound = Instantiate(buildSoundTemplate);
            buildSound.transform.position = transform.position;
        }
    }
}
