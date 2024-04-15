using TMPro;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    public string message = string.Empty;
    public float displayTime = 5f;
    public GameObject infoScreen;
    
    private Transform _player;
    private bool _hasFired;
    private float _timeSinceFired;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (_hasFired)
        {
            _timeSinceFired += Time.deltaTime;

            if (_timeSinceFired > displayTime)
            {
                infoScreen.SetActive(false);
                Destroy(gameObject);
            }
            
            return;
        }

        if (_player.position.x > transform.position.x)
        {
            infoScreen.SetActive(true);
            infoScreen.GetComponent<TextMeshProUGUI>().text = message;
            _hasFired = true;
            _timeSinceFired = 0;
        }
    }
}
