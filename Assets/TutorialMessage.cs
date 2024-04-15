using System.Collections.Generic;
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

        if (_player.position.x > transform.position.x && !_hasFired)
        {
            infoScreen.SetActive(true);
            infoScreen.GetComponent<TextMeshProUGUI>().text = message;
            InfoScreen infoScreenData = infoScreen.GetComponent<InfoScreen>();
            if (!(infoScreenData.previousWriter == null))
                infoScreenData.previousWriter.GiveOwnershipAway();
            infoScreenData.previousWriter = this;
            _hasFired = true;
            _timeSinceFired = 0;

        }
    }

    public void GiveOwnershipAway()
    {
        Destroy(gameObject);
    }
}
