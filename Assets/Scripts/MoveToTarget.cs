using Unity.VisualScripting;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public GameObject explosionTemplate;

    private Vector3 lastTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target.IsDestroyed() is false)
        {
            lastTargetPosition = target.position;
        }

        Rotate();

        //var targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        var velocity = (lastTargetPosition - transform.position).normalized * moveSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, lastTargetPosition, ref velocity, 0.5f, Time.deltaTime);

        if (Vector3.Distance(transform.position, lastTargetPosition) <= 0.3f)
        {
            if (target.IsDestroyed() is false)
            {
                target.GetComponent<EntityWithHealth>().ApplyDamage(10);    
            }

            if (explosionTemplate != null)
            {
                var explosion = Instantiate(explosionTemplate);
                explosion.transform.position = transform.position;
            }
            
            Destroy(gameObject);
        }
    }

    private void Rotate()
    {
        var dir = transform.position - lastTargetPosition;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}