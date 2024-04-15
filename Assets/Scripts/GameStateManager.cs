using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public TextMeshProUGUI timeField;
    public TextMeshProUGUI currencyField;
    public TextMeshProUGUI healthField;

    public int currency;

    public GameObject winScreen;
    public GameObject deathScreen;

    private static GameStateManager Instance;

    private float _gameTime;
    private int _health = MaxHealth;
    private int _lastBaseIncome;

    public bool IsInMainMenu { get; set; }

    private const int MaxHealth = 100;
    private const int BaseIncome = 5;
    private const int BaseIncomeRhythm = 5;

    // Update is called once per frame
    void Update()
    {
        _gameTime += Time.deltaTime;

        if (IsInMainMenu)
            return;
        CheckForVictory();
        UpdateTextfields();
        AddBaseIncome();
    }

    // private void Awake()
    // {
    //     if (Instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    //
    //     Instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }

    private void CheckForVictory()
    {
        var spawners = FindObjectsOfType<Spawner>();
        var enemies = FindObjectsOfType<WaypointFollower>().Where(i => i.IsDestroyed() is false);
        if (spawners.All(i => i.isDone) && enemies.Any() is false)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
            // TODO: Go to next level / victory screen
        }
    }

    private void UpdateTextfields()
    {
        timeField.SetText($"Time: {TimeSpan.FromSeconds(_gameTime):mm\\:ss}");
        currencyField.SetText($"Souls: {currency}");
        healthField.SetText($"{_health}/{MaxHealth}");
        if (_health <= MaxHealth * 0.2)
        {
            healthField.fontStyle = FontStyles.Bold;
            healthField.color = Color.red;
        }
    }

    private void AddBaseIncome()
    {
        var time = (int)_gameTime;
        if (time % BaseIncomeRhythm == 0 && time > _lastBaseIncome)
        {
            _lastBaseIncome = time;
            AddCurrency(BaseIncome);
        }
    }

    public int AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd;

        return currency;
    }

    public int GetCurrency() => currency;

    public int AddDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            var mainBuilding = GameObject.FindGameObjectWithTag("MainBuilding");
            mainBuilding.GetComponent<DestroyableBuilding>().Destroy();
            Destroy(mainBuilding);

            deathScreen.SetActive(true);
        }

        return _health;
    }
}
