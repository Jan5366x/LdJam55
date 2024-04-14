using System;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public TextMeshProUGUI timeField;
    public TextMeshProUGUI currencyField;
    public TextMeshProUGUI healthField;

    public int currency;

    private float gameTime;
    private int health = MaxHealth;
    private int lastBaseIncome;

    private const int MaxHealth = 100;
    private const int BaseIncome = 5;
    private const int BaseIncomeRhythm = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        timeField.SetText($"Time: {TimeSpan.FromSeconds(gameTime):mm\\:ss}");
        currencyField.SetText($"Souls: {currency}");
        healthField.SetText($"{health}/{MaxHealth}");
        if (health <= MaxHealth * 0.2)
        {
            healthField.fontStyle = FontStyles.Bold;
            healthField.color = Color.red;
        }

        AddBaseIncome();
    }

    private void AddBaseIncome()
    {
        var time = (int)gameTime;
        if (time % BaseIncomeRhythm == 0 && time > lastBaseIncome)
        {
            lastBaseIncome = time;
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
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Game lost");
            // TODO: Handle lost game
        }

        return health;
    }
}
