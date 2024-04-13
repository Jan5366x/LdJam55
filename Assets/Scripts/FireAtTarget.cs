using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtTarget : MonoBehaviour
{
    public Transform target;

    public GameObject projectile;

    public float fireRate;

    private Transform weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.Find("Weapon");
        var projectileObject = Instantiate(projectile, weapon.position, Quaternion.identity);
        var moveScript = projectileObject.GetComponent<MoveToTarget>();
        moveScript.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
