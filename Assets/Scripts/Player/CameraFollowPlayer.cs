using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public RectTransform worldLimiter;
    public float moveSpeed;

    private Vector3 _targetPos;
    private Transform _followTarget;
    private Camera _camera;

    void Start()
    {
        _followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _camera = GetComponent<Camera>();
    }

    void Update()
    {


        if (_followTarget is not null)
        {
            _targetPos = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
            Vector3 velocity = (_targetPos - transform.position) * moveSpeed;
            Vector3 targetPosition = Vector3.SmoothDamp(transform.position, _targetPos, ref velocity, 5.0f, Time.deltaTime);
            targetPosition = ClampIntoBoundaries(targetPosition);
            transform.position = targetPosition;
        }
    }

    private Vector3 ClampIntoBoundaries(Vector3 newPosition)
    {
        Vector3 currentPosition = transform.position;
        Rect rect = worldLimiter.rect;
        Vector2 topRight = (Vector2)worldLimiter.position + new Vector2(rect.width / 2, rect.height / 2);
        Vector2 bottomLeft = (Vector2)worldLimiter.position - new Vector2(rect.width / 2, rect.height / 2);

        Vector3 topRightViewport = _camera.WorldToViewportPoint(topRight);
        Vector3 bottomLeftViewport = _camera.WorldToViewportPoint(bottomLeft);

        // Debug.LogFormat("{5}, Contained: {4} in: {0} : {1} : {2} : {3}",
        //     topRightViewport.x > 1, topRightViewport.y > 1, bottomLeftViewport.x < 0, bottomLeftViewport.y < 0,
        //     topRightViewport is { x: > 1, y: > 1 } && bottomLeftViewport is { x: < 0, y: < 0 },
        //     gameObject.name);
        // push back
        if (topRightViewport.x < 1)
            newPosition.x = newPosition.x < currentPosition.x ? newPosition.x : currentPosition.x;
        if (topRightViewport.y < 1)
            newPosition.y = newPosition.y < currentPosition.y ? newPosition.y : currentPosition.y;
        if (bottomLeftViewport.x > 0)
            newPosition.x = newPosition.x > currentPosition.x ? newPosition.x : currentPosition.x;
        if (bottomLeftViewport.y > 0)
            newPosition.y = newPosition.y > currentPosition.y ? newPosition.y : currentPosition.y;
        return newPosition;

        // if (topRightViewport.x < 1)
        //     newPosition.x = newPosition.x < currentPosition.x ? newPosition.x : currentPosition.x;
        // if (topRightViewport.y < 1)
        //     newPosition.y = currentPosition.y;
        // if (bottomLeftViewport.x > 0)
        //     newPosition.x = currentPosition.x;
        // if (bottomLeftViewport.y > 0)
        //     newPosition.y = currentPosition.y;
    }
}
