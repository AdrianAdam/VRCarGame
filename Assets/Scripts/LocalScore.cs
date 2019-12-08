using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocalScore : MonoBehaviour
{
    public Text scoreText;
    public GameObject pauseMenuUI;

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

    void Update()
    {
        if(bPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            string textFirstPart = string.Concat("Score for ", sceneName);
            scoreText.text = string.Concat(textFirstPart + ": ", PlayerPrefs.GetInt(sceneName, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        controller.currentPoints += 500;

        if(controller.currentPoints > PlayerPrefs.GetInt(sceneName, 0))
        {
            PlayerPrefs.SetInt(sceneName, controller.currentPoints);
        };

        bPaused = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.name, "VehicleCollider") && string.Equals(transform.name, "FinishLine"))
        {
            controller.currentPoints += 500;

            if (controller.currentPoints > PlayerPrefs.GetInt(sceneName, 0))
            {
                PlayerPrefs.SetInt(sceneName, controller.currentPoints);
            }
        }

        bPaused = true;
    }
}
