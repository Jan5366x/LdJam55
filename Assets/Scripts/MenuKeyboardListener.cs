using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractionListener : MonoBehaviour
{
    private GameSettingsManager _gameSettingsManager = null;

    // Start is called before the first frame update
    void Start()
    {
        // _gameSettingsManager = GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _gameSettingsManager ??= GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>();
        if (!_gameSettingsManager.IsInMainMenu)
            return;

        bool escPressed = Input.GetButtonDown("Cancel");
        bool onlyMenuIsActive = SceneManager.sceneCount == 1;
        if (escPressed && !onlyMenuIsActive)
        {
            Time.timeScale = 1f;
            _gameSettingsManager.IsInMainMenu = false;
            SceneManager.UnloadSceneAsync("MainMenu");
            return;
        }
    }
}
