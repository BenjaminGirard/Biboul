using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Projectile")
        {
            if (collision.relativeVelocity.magnitude > 4)
                Destroy(gameObject);
        }
    }
}
