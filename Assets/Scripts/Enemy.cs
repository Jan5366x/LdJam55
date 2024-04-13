using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float attackDamge;
    public float attacksPerSecond;
    public UnityEvent diedEvent;

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
    /// <param name="damage"></param>
    /// <returns>Whether the entity has died</returns>
    public bool ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            diedEvent.Invoke();
            return true;
        }

        return false;
    }
}
