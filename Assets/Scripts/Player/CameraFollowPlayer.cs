using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float moveSpeed;
    
    private Vector3 _targetPos;
    private Transform _followTarget;

    void Start()
    {
        _followTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (_followTarget is not null)
        {
            _targetPos = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
            Vector3 velocity = (_targetPos - transform.position) * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref velocity, 5.0f, Time.deltaTime);
        }
    }
}