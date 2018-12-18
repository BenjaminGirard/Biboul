using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour {
	[SerializeField]
	GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			GameObject tmpExplosionPrefab = Instantiate(explosionPrefab, pos, rot);
			Destroy(tmpExplosionPrefab, 0.2f);
		}
	}
}
