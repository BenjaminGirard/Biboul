using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public GameObject attractionObject;
    public float force = 2;

    // Use this for initialization
    void Start () {    
	}
	
	Vector3 NearestVertexTo()
	{
		// convert point to local space
		Vector3 point = this.transform.position;


		Mesh mesh = attractionObject.GetComponent<MeshCollider>().sharedMesh;
		float minDistanceSqr = Mathf.Infinity;
		Vector3 nearestVertex = Vector3.zero;
		float distSqr;
		Vector3 diff;
		// scan all vertices to find nearest
		foreach (Vector3 vertex in mesh.vertices)
		{
			diff = point - vertex;
			distSqr = diff.sqrMagnitude;
			if (distSqr < minDistanceSqr)
			{
				minDistanceSqr = distSqr;
				nearestVertex = vertex;
			}
		}

		Debug.Log(nearestVertex);
		// convert nearest vertex back to world space
		return nearestVertex;

	}

	// Update is called once per frame
	void Update () {
        if (attractionObject == null)
            return;
        //float distance = Vector3.Distance(this.transform.position, attractionObject.transform.position);
//        Debug.Log(attractionObject.transform.position);
//        Vector3 closestPoint = attractionObject.GetComponent<Collider>().ClosestPoint(this.transform.position);
//        Vector3 closestPoint = NearestVertexTo();
		Vector3 closestPoint = attractionObject.GetComponent<Collider>().bounds.ClosestPoint(this.transform.position);
		Vector3 vector = closestPoint - this.transform.position;
        this.GetComponent<Rigidbody>().AddForce(vector * force);

/*		Quaternion rotation = this.transform.rotation;
		Vector2 axe = Vector2.up;
		Vector2 tmp;
		tmp.y = this.transform.position.y - closestPoint.y;
		tmp.x = this.transform.position.x - closestPoint.x;
		rotation.z = Vector2.Angle(axe, tmp);
		tmp.x = this.transform.position.z - closestPoint.z;
		rotation.x = Vector2.Angle(axe, tmp);
		this.transform.rotation = rotation;*/

	}
}
