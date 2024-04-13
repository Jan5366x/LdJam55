using UnityEngine;

public class FireAtTarget : MonoBehaviour
{
    public Transform target;

    public GameObject projectile;

    // 10 == one shot per second
    public float fireRate;

    private Transform weapon;
    private float timeSinceLastShot = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.Find("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= (10 / fireRate))
        {
            timeSinceLastShot = 0;
            var projectileObject = Instantiate(projectile, weapon.position, Quaternion.identity);
            var moveScript = projectileObject.GetComponent<MoveToTarget>();
            moveScript.target = target; 
        }
    }
}
