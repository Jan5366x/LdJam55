using UnityEngine;

public class SpatialSound : MonoBehaviour
{
    public float minDist = 1;
    public float maxDist = 6;

    private Transform _listener;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _listener = GameObject.FindGameObjectWithTag("Player").transform;
        Update();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, _listener.position);

        if (dist < minDist)
        {
            _audioSource.volume = 1;
        }
        else if (dist > maxDist)
        {
            _audioSource.volume = 0;
        }
        else
        {
            _audioSource.volume = 1 - ((dist - minDist) / (maxDist - minDist));
        }
    }
}
