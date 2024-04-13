using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EntityWithHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public UnityEvent diedEvent;
    public int unitValue;

    [Range(0, 1)]
    public float physicalResistance;
    [Range(0, 1)]
    public float magicalResistance;
    void Start()
    {
        diedEvent = new();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="damage">amount of damage</param>
    /// <param name="damageType">Damage type of the projectile</param>
    /// <returns>Whether the entity has died</returns>
    public bool ApplyDamage(float damage, DamageType damageType = DamageType.None)
    {
        float damageTaken = damageType switch
        {
            DamageType.Magical => damage * (1f - magicalResistance),
            DamageType.Physical => damage * (1f - physicalResistance),
            DamageType.None => damage,
            _ => throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null)
        };
        health -= damageTaken;
        if (health <= 0)
        {
            diedEvent.Invoke();
            Destroy(gameObject);
            GameObject stateManger = GameObject.FindGameObjectWithTag("GameStateManager");
            stateManger.GetComponent<GameStateManager>().AddCurrency(unitValue);
            return true;
        }

        return false;
    }
}
