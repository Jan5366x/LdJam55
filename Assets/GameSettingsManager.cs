using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameSettingsManager : MonoBehaviour
{
    public int volume;

    public static GameSettingsManager Instance;


    [field: SerializeField]
    public bool IsInMainMenu { get; set; }
    // public bool IsInMainMenu
    // {
    //     get
    //     {
    //         Enumerable.Range(0, SceneManager.sceneCount).Select(x => SceneManager.GetSceneAt(x))
    //             .Any(x => x.name == "MainMenu");
    //     }
    //     set => isInMainMenu = value;
    // }

    public AudioMixer audioMixer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        IsInMainMenu = SceneManager.GetActiveScene().name == "MainMenu";
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
        audioMixer.SetFloat("MasterVolume", MathF.Log10((volume != 0 ? volume : 0.0001f) / 100) * 20);
    }
}
