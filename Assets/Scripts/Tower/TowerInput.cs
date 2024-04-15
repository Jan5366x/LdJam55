using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerInput : MonoBehaviour
{
    public GameObject towerTemplate;
    public GameObject player;
    public GameStateManager gameStateManager;

    public float buildRadius = 1.5f;
    public int buildCosts = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = player != null ? player : GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void Fired()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("TowerBuildingSlot");
        GameObject slot = slots
            .Where(x => Vector3.Distance(player.transform.position, x.transform.position) <= buildRadius)
            .OrderBy(x => Vector3.Distance(player.transform.position, x.transform.position))
            .FirstOrDefault();

        if (slot is null)
        {
            GameObject.Find("Info Text").GetComponent<AutoClearTextfield>().SetText("No Buildslot in range");
            return;
        }

        var towerSlot = slot.GetComponent<TowerSlot>();
        if (!towerSlot.isOccupied && gameStateManager.GetCurrency() >= buildCosts)
        {
            gameStateManager.AddCurrency(-buildCosts);
            GameObject tower = Instantiate(towerTemplate, slot.transform);
            tower.transform.position = slot.transform.position;
            towerSlot.isOccupied = true;
            towerSlot.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }
}
