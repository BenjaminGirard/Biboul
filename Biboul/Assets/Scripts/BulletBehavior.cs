using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	private float speed;
	public Vector3 target;
	private bool isDestroyed;

	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}

	public Vector3 Target
	{
		get { return target; }
		set { target = value; }
	}

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
	}
}
