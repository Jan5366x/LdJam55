    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float timeUntilGone = 5;

    private float _accumulatedTime = 0f;

    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _accumulatedTime += Time.deltaTime;

        renderer.color = new Color(1, 1, 1, 1 - Clamp(_accumulatedTime / timeUntilGone));
    }

    private float Clamp(float value) =>
        value switch
        {
            <= 0 => 0,
            >= 1 => 1,
            _ => value,
        };
}
