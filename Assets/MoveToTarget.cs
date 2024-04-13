using System.Collections;
using System.Collections.Generic;
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
            //transform.LookAt(target);
            //transform.rotation = Quaternion.FromToRotation(target.position, transform.position);
            
            Vector3 dir = transform.position - target.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            var targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 5.0f, Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.3f)
            {
                Destroy(gameObject);
            }
        }
    }
}
