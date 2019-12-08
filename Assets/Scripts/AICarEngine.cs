using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarEngine : MonoBehaviour
{
	public Transform path;
	public float maxSteerAngle = 45f;
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxMotorTorque = 10000f;
    public float maxBreakTorque = 40000f;
	public float currentSpeed;
	public float maxSpeed = 130f;
	public Vector3 centerOfMass;
    public GameObject brakingLightOn;
    public bool isBraking = false;

	private List<Transform> nodes;
	private int currentNode = 0;

    void Start()
    {
		GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
		nodes = new List<Transform>();

		for(int i = 0; i < pathTransforms.Length; i++)
		{
			if(pathTransforms[i] != path.transform)
			{
				nodes.Add(pathTransforms[i]);
			}
		}
    }

    void FixedUpdate()
    {
        ApplySteer();
		Drive();
		CheckWaypointDistance();
        Braking();
    }

	void ApplySteer()
	{
		Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
		wheelFL.steerAngle = newSteer;
		wheelFR.steerAngle = newSteer;
	}

	void Drive()
	{
		currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

		if(currentSpeed < maxSpeed && !isBraking)
		{
			wheelFL.motorTorque = maxMotorTorque;
			wheelFR.motorTorque = maxMotorTorque;
		}
		else
		{
			wheelFL.motorTorque = 0;
			wheelFR.motorTorque = 0;
		}
	}

	void CheckWaypointDistance()
	{
		if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
		{
			if(currentNode == nodes.Count - 1)
			{
				currentNode = 0;
			}
			else
			{
				currentNode++;
			}
		}
	}

    private void Braking()
    {
        if(isBraking)
        {
            brakingLightOn.active = true;
            wheelRL.brakeTorque = maxBreakTorque;
            wheelRR.brakeTorque = maxBreakTorque;
        }
        else
        {
            brakingLightOn.active = false;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }
}
