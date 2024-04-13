using JetBrains.Annotations;
using UnityEngine;

[ExecuteInEditMode]
public class FireAtTarget : MonoBehaviour
{
    public GameObject projectile;

    // 10 == one shot per second
    public float fireRate;
    public float maxRange;

    // public Transform weapon;
    private Transform weapon;
    [CanBeNull]
    private Transform target;
    private float timeSinceLastShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.Find("TowerGraphics/Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= (10 / fireRate))
        {
            FindNearestTarget();
            if (target is not null)
            {
                timeSinceLastShot = 0;
                var projectileObject = Instantiate(projectile, weapon.position, Quaternion.identity);
                var moveScript = projectileObject.GetComponent<MoveToTarget>();
                moveScript.target = target;
            }
        }
    }

    private void FindNearestTarget()
    {
        // TODO: Internet says this is bad for performance :(
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nextTarget = null;
        var nextTagetDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            var dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < maxRange && dist < nextTagetDistance)
            {
                nextTarget = enemy;
                nextTagetDistance = dist;
            }
        }

        target = nextTarget?.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.Find("TowerGraphics/Weapon").transform.position, maxRange);
    }
}
