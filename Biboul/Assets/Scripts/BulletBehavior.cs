using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	private float speed;
	private Vector3 target;
	private bool isDestroyed;
	private Animator anim;
	private Rigidbody _rigidbody;

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
		anim = transform.GetComponent<Animator>();
		_rigidbody = transform.GetComponent<Rigidbody>();
		_rigidbody.AddForce((target - transform.position) * 60);
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
//		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
	}

	private void OnDestroy()
	{
//		anim.Play("ProjectileClear");
	}
}
