using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	private float speed;
	public Transform target;
	private bool isDestroyed;
	private Animator anim;

	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}

	public Transform Target
	{
		get { return target; }
		set { target = value; }
	}

	// Use this for initialization
	void Start ()
	{
		anim = transform.GetComponent<Animator>();
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
	}

	private void OnDestroy()
	{
		anim.Play("ProjectileClear");
	}
}
