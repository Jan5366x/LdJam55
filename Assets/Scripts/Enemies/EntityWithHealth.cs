using System;
using UnityEngine;

public class EntityWithHealth : MonoBehaviour
{
    public GameObject deathAnimationTemplate;
    public float health;
    public int unitValue;

    [Range(0, 1)] public float physicalResistance;
    [Range(0, 1)] public float magicalResistance;

    /// <summary>
    ///
    /// </summary>
    /// <param name="damage">amount of damage</param>
    /// <param name="damageType">Damage type of the projectile</param>
    /// <returns>Whether the entity has died</returns>
    public bool ApplyDamage(float damage, DamageType damageType = DamageType.None)
    {
        var damageTaken = damageType switch
        {
            DamageType.Magical => damage * (1f - magicalResistance),
            DamageType.Physical => damage * (1f - physicalResistance),
            DamageType.None => damage,
            _ => throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null)
        };

        health -= damageTaken;
        if (health <= 0)
        {
            StartDeathAnimation();
            SendKillReward();
            Destroy(gameObject);

            return true;
        }

        return false;
    }

    private void StartDeathAnimation()
    {
        if (deathAnimationTemplate != null)
        {
            var deathAnimation = Instantiate(deathAnimationTemplate);
            deathAnimation.transform.position = transform.position;
        }
    }

    private void SendKillReward()
    {
        GameObject stateManger = GameObject.FindGameObjectWithTag("GameStateManager");
        stateManger.GetComponent<GameStateManager>().AddCurrency(unitValue);
    }
}