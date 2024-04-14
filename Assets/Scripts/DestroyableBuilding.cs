using UnityEngine;

public class DestroyableBuilding : MonoBehaviour
{
    public GameObject destroyedTemplate;

    public void Destroy()
    {
        Instantiate(destroyedTemplate, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}
