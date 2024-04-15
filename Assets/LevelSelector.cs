using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameSettingsManager gameSettingsManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelSelected(string level)
    {
        // Also dumps current levels and the main menu

        GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>().IsInMainMenu = false;
        // gameSettingsManager.IsInMainMenu = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void OnContinue()
    {
        if (SceneManager.sceneCount <= 1)
            return;
        Time.timeScale = 1f;
        GameObject.Find("GameSettingsManager").GetComponent<GameSettingsManager>().IsInMainMenu = false;
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
