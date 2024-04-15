using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float timeUntilGone = 5;

    private float _accumulatedTime = 0f;

    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        _accumulatedTime += Time.deltaTime;
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f - Clamp(_accumulatedTime / timeUntilGone));
    }

    private float Clamp(float value) =>
        value switch
        {
            <= 0 => 0,
            >= 1 => 1,
            _ => value,
        };
}
