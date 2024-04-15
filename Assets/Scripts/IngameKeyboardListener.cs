using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameKeyboardListener : MonoBehaviour
{
    private GameStateManager _gameStateManager;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        _gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStateManager.IsInMainMenu)
            return;
        movement.verticalInput = Input.GetAxis("Vertical");
        movement.horizontalInput = Input.GetAxis("Horizontal");


        bool escPressed = Input.GetButtonDown("Cancel");
        if (escPressed)
        {
            Time.timeScale = 0;
            _gameStateManager.IsInMainMenu = true;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
    }
}
