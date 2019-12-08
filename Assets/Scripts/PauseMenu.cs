using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Text scoreText;
    public GameObject pauseMenuUI;

    private string sceneName;
    private static bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 1"))
        {
            if(gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        string textFirstPart = string.Concat("Score for ", sceneName);
        scoreText.text = string.Concat(textFirstPart + ": ", PlayerPrefs.GetInt(sceneName, 0));
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}
