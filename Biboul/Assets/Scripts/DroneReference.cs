using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneReference : MonoBehaviour
{
	public DroneBehavior droneBehavior;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Attack()
	{
		droneBehavior.Attack();
	}
}
