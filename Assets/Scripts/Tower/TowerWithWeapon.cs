using UnityEngine;

[ExecuteInEditMode]
public class TowerWithWeapon : MonoBehaviour
{
    public GameObject projectile;

    // 10 == one shot per second
    public float fireRate;
    public float maxRange;
    public int damage;

    // public Transform weapon;
    private Transform _weapon;
    private Transform _target;
    private float _timeSinceLastShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        _weapon = transform.Find("TowerGraphics/Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (_timeSinceLastShot >= (10 / fireRate))
        {
            FindNearestTarget();
            if (_target is not null)
            {
                LaunchProjectile();
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
            var dist = Vector3.Distance(_weapon.transform.position, enemy.transform.position);
            if (dist < maxRange && dist < nextTagetDistance)
            {
                nextTarget = enemy;
                nextTagetDistance = dist;
            }
        }

        _target = nextTarget?.transform;
    }

    private void LaunchProjectile()
    {
        _timeSinceLastShot = 0;
        var projectileObject = Instantiate(projectile, _weapon.position, Quaternion.identity);
        var moveScript = projectileObject.GetComponent<MovingProjectile>();
        moveScript.target = _target;
        moveScript.damage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.Find("TowerGraphics/Weapon").transform.position, maxRange);
    }
}