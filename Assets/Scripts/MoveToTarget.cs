using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target is not null)
        {
            Vector3 dir = transform.position - target.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            var targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position).normalized * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 5.0f, Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.3f)
            {
                target.GetComponent<EntityWithHealth>().ApplyDamage(10);
                Destroy(gameObject);
            }
        }
    }
}
