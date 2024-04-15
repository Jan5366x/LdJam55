using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractionListener : MonoBehaviour
{
    private GameStateManager _gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        // TODO Audio listener
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStateManager.IsInMainMenu)
            return;

        bool escPressed = Input.GetButtonDown("Cancel");
        if (escPressed)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            Time.timeScale = 1f;
            _gameStateManager.IsInMainMenu = false;
            return;
        }
    }
}
