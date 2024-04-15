using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameKeyboardListener : MonoBehaviour
{
    private GameStateManager _gameStateManager;
    public Movement movement;
    private GameSettingsManager _gameSettingsManager;
    public TowerInput towerInput;

    // Start is called before the first frame update
    void Start()
    {
        _gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        _gameSettingsManager = GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementVerticalInput = Input.GetAxis("Vertical");
        float movementHorizontalInput = Input.GetAxis("Horizontal");
        bool escPressed = Input.GetButtonDown("Cancel");
        bool firePressed = Input.GetButtonDown("Fire1");

        if (_gameSettingsManager.IsInMainMenu)
            return;

        if (firePressed)
            towerInput.Fired();
        movement.verticalInput = movementVerticalInput;
        movement.horizontalInput = movementHorizontalInput;


        if (escPressed)
        {
            Time.timeScale = 0;
            _gameSettingsManager.IsInMainMenu = true;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
    }
}
