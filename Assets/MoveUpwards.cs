using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpwards : MonoBehaviour
{
    public float speed = 1.5f;
    // public float wiggleHorizontalRange;
    // public float wiggleHorizontalFrequency;

    private float _accumulatedTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _accumulatedTime += Time.deltaTime;
        Vector3 currentPos = transform.position;

        transform.position = currentPos + (Vector3.up * (speed * Time.deltaTime));

    }
}
