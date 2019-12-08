using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    private GameObject control;
    private MSSceneControllerFree controller;

    void Start()
    {
        control = GameObject.Find("Control");
        controller = control.GetComponent<MSSceneControllerFree>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "VehicleCollider")
        {
            controller.currentPoints += 50;
        }
    }
}
