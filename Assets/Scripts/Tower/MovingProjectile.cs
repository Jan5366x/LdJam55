using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingProjectile : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public GameObject explosionTemplate;
    public GameObject explosionSoundTemplate;
    
    public Vector3 targetOffset = new (0, 0.2f);

    public int damage;

    private Vector3 _lastTargetPosition;

    // Update is called once per frame
    void Update()
    {
        if (target.IsDestroyed() is false)
        {
            _lastTargetPosition = target.position + targetOffset;
        }

        Rotate();
        MoveRocket();
        
        if (transform.position == _lastTargetPosition)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        if (target.IsDestroyed() is false)
        {
            target.GetComponent<EntityWithHealth>().ApplyDamage(damage);    
        }

        if (explosionSoundTemplate != null)
        {
            var explosion = Instantiate(explosionSoundTemplate);
            explosion.transform.position = transform.position;
        }
        
        if (explosionTemplate != null)
        {
            var explosion = Instantiate(explosionTemplate);
            explosion.transform.position = transform.position;
        }
            
        Destroy(gameObject);
    }

    private void MoveRocket()
    {
        var velocity = (_lastTargetPosition - transform.position).normalized * moveSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, _lastTargetPosition, ref velocity, 0.5f, Time.deltaTime);
    }

    private void Rotate()
    {
        var dir = transform.position - (_lastTargetPosition);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}