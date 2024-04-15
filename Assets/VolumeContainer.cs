using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeContainer : MonoBehaviour
{
    private GameSettingsManager _gameSettingsManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameSettingsManager = GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>();
        Slider slider = transform.GetComponent<Slider>();
        slider.value = _gameSettingsManager.volume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnVolumeChanged(float volume)
    {
        _gameSettingsManager.OnVolumeUpdated(volume);
    }
}
