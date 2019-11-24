using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBetweenCars : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject uiDistanceText;

    private GameObject control;
    private MSSceneControllerFree controller;

    private int minDistanceBetweenVehicles = 20;
    private float timeSinceLastMessage = 0;
    private float globalTime = 0;
    private bool showText = false;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Control");
        controller = control.GetComponent<MSSceneControllerFree>();
        uiDistanceText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;

        float dist = Vector3.Distance(vehicle.transform.position, transform.position);
            
        if(dist < minDistanceBetweenVehicles && globalTime - timeSinceLastMessage > 2)
        {
            timeSinceLastMessage = globalTime;
            controller.currentPoints -= 100;
            showText = true;
            uiDistanceText.SetActive(true);
        }
        else
        {
            showText = false;
        }
    }
}
