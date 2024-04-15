using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    public int volume;

    public static GameSettingsManager Instance;
    public bool IsInMainMenu { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnVolumeUpdated(float volume)
    {
        this.volume = (int)volume;
        // Debug.Log($"Settings manager has received volume of {volume}");
    }
}
