using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessage : MonoBehaviour
{
    public string message = string.Empty;
    public TextMeshProUGUI infoText;
    
    private Transform _player;
    private bool _hasFired;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasFired)
        {
            return;
        }

        if (_player.position.x > transform.position.x)
        {
            infoText.SetActive(true);
            infoScreen.GetComponentInChildren<TextMeshPro>().GetComponent<TextMeshProUGUI>().text = message;
        }
    }
}
