using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerfectParking : MonoBehaviour
{
    public Text scoreText;
    public GameObject pauseMenuUI;
    public GameObject car;

    private string sceneName;
    private bool bPaused;

    private GameObject control;
    private MSSceneControllerFree controller;

    void Start()
    {
        control = GameObject.Find("Control");
        controller = control.GetComponent<MSSceneControllerFree>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 0"))
        {
            if (GetComponent<Collider>().bounds.Contains(car.transform.position))
            {
                bPaused = true;

                controller.currentPoints += 500;

                if (controller.currentPoints > PlayerPrefs.GetInt(sceneName, 0))
                {
                    PlayerPrefs.SetInt(sceneName, controller.currentPoints);
                };
            }
        }

        if (bPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            string textFirstPart = string.Concat("Score for ", sceneName);
            scoreText.text = string.Concat(textFirstPart + ": ", PlayerPrefs.GetInt(sceneName, 0));
        }
    }
}
