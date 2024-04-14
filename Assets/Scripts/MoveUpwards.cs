using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveUpwards : MonoBehaviour
{
    public float speed = 1.5f;
    public float wiggleHorizontalRange = 0.1f;
    public float wiggleHorizontalFrequency = 0.5f;

    private float _accumulatedTime;
    private float originalX;

    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _accumulatedTime += Time.deltaTime;
        Vector3 currentPos = transform.position;

        float offset = MathF.Sin((MathF.PI * wiggleHorizontalFrequency) * _accumulatedTime) * wiggleHorizontalRange;
        Vector3 upMovement = (Vector3.up * (speed * Time.deltaTime));
        Vector3 sideMovement = Vector3.right * offset;
        transform.position = currentPos + upMovement + sideMovement;

    }
}
