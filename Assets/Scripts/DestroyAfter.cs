using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    // Time in seconds
    public float Destroytime;

    private float timeAlive;

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= Destroytime)
        {
            Destroy(gameObject);
        }
    }
}