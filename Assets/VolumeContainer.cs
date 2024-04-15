using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnVolumeChanged(float volume)
    {
        GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>().OnVolumeUpdated(volume);
    }
}
