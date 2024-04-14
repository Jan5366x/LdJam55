using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed;
    
    private Vector3 targetPos;

    void Update()
    {
        if (followTarget is not null)
        {
            targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 5.0f, Time.deltaTime);
        }
    }
}