using System;
using UnityEngine;

public class WaveVertical : MonoBehaviour
{
    public float waveFrequency;
    public float waveRange;
    
    private Vector3 _originalPosition;
    private float _accumulatedTime;
    
    void Start()
    {
        _originalPosition = transform.position + new Vector3(0, 0.3f, 0);
    }
    
    void Update()
    {
        _accumulatedTime += Time.deltaTime;
        
        var offset = MathF.Sin((MathF.PI * waveFrequency) * _accumulatedTime) * waveRange;
        transform.position = _originalPosition + new Vector3(0, offset, 0);
    }
}
