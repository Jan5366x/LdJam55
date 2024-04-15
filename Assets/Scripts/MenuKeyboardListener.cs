using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractionListener : MonoBehaviour
{
    private GameStateManager _gameStateManager;

    private GameSettingsManager _gameSettingsManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        _gameSettingsManager = GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>();
        
        // TODO Audio listener
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameSettingsManager.IsInMainMenu)
            return;

        bool escPressed = Input.GetButtonDown("Cancel");
        if (escPressed)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            Time.timeScale = 1f;
            _gameSettingsManager.IsInMainMenu = false;
            return;
        }
    }
}
