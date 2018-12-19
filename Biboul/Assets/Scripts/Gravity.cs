using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public GameObject attractionObject = null;
    private float force = 9.8f;
    private Vector3 direction = new Vector3(0f, 0f, 0f);
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        if (tag != "Ennemy")
        {
            attractionObject = GameObject.FindGameObjectWithTag("Down");
        }
    }

    private void Update()
    {
        if (attractionObject == null)
        {
            return;
        }
        Vector3 closestPoint = attractionObject.GetComponent<Collider>().bounds.ClosestPoint(transform.position);
        direction = closestPoint - transform.position;
    }
    // Update is called once per frame
    void FixedUpdate () {

        //float distance = Vector3.Distance(this.transform.position, attractionObject.transform.position);
//        Debug.Log(attractionObject.transform.position);
//        Vector3 closestPoint = attractionObject.GetComponent<Collider>().ClosestPoint(this.transform.position);
//        Vector3 closestPoint = NearestVertexTo();
        GetComponent<Rigidbody>().AddForce(direction.normalized * force);//, ForceMode.Acceleration);

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
