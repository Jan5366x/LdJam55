using System;
using UnityEngine;
using Random = System.Random;

public class MoveUpwards : MonoBehaviour
{
    public float speed = 1.5f;
    public float wiggleHorizontalRange = 0.1f;
    public float wiggleHorizontalFrequency = 0.5f;

    private float _accumulatedTime;
    private Vector3 _wiggleDirection;

    private void Start()
    {
        _wiggleDirection = new Random().Next(0, 10) switch
        {
            > 5 => Vector3.right,
            _ => Vector3.left,
        };
    }

    private void Update()
    {
        _accumulatedTime += Time.deltaTime;
        Vector3 currentPos = transform.position;

        float offset = MathF.Sin((MathF.PI * wiggleHorizontalFrequency) * _accumulatedTime) * wiggleHorizontalRange;
        Vector3 upMovement = (Vector3.up * (speed * Time.deltaTime));
        Vector3 sideMovement = _wiggleDirection * offset;
        transform.position = currentPos + upMovement + sideMovement;
    }
}
