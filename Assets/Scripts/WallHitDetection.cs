using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitDetection : MonoBehaviour
{
    private GameObject control;
    private MSSceneControllerFree controller;

	void Start()
	{
		control = GameObject.Find("Control");	
		controller = control.GetComponent<MSSceneControllerFree>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if(!string.Equals(collision.gameObject.name, "FinishLine") && !string.Equals(collision.gameObject.name, "Street"))
        {
            controller.currentPoints -= 100;
        }
	}
}
