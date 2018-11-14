using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class DroneBehavior : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float attackCooldown;

	private bool isAggro;

	private Animator anim;
	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	private Renderer droneEye;

	private float timeStamp;

	// Use this for initialization
	void Start ()
	{
		anim = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
		droneEye = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>();
		timeStamp = Time.time + attackCooldown;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance(transform.position, target.position) < 12)
		{
			isAggro = true;
			droneEye.material.color = Color.red;
		}
		else
		{
			isAggro = false;
			droneEye.material.color = new Color(80,80,80);
		}
		if (isAggro)
		{
			transform.LookAt(target);
			if (Vector3.Distance(transform.position, target.position) < 8)
			{
				if (timeStamp <= Time.time)
				{
					anim.Play("Attack");
					timeStamp = Time.time + attackCooldown;
				}
			}
			else
 			{
				anim.Play("Move");
				transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);	
			}
		}
	}

	public void Attack()
	{
		GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		bullet.GetComponent<BulletBehavior>().Target = target;
		bullet.GetComponent<BulletBehavior>().Speed = 6;
	}
}
