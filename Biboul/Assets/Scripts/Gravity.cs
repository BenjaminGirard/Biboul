using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    private GameObject pivot;

    public GameObject attractionObject;
    private float force = 9.81f;

    private static Dictionary<string, Vector3> gravityRef;
    private static Dictionary<string, Vector3> rotationRef;
    private static Dictionary<string, float> angleRef;

    private Quaternion targetRotation;
    public float smooth = 100f;

    // Use this for initialization
    void Start()
    {


        angleRef = new Dictionary<string, float>
        {
             { "Up", 180f},
            { "Down", 0f},
            { "Back", -90f},
            { "Forward", 90f},
            { "Left", -90f},
            { "Right", 90f},
        };
        gravityRef = new Dictionary<string, Vector3> {
            { "Up", new Vector3(0f, force, 0f)},
            { "Down", new Vector3(0f, -force, 0f)},
            { "Back", new Vector3(0f, 0f, -force)},
            { "Forward", new Vector3(0f, 0f, force)},
            { "Left", new Vector3(-force, 0f, 0f)},
            { "Right", new Vector3(force, 0f, 0f)},
        };
        rotationRef = new Dictionary<string, Vector3> {
            { "Up", new Vector3(1f, 0f, 0f)},
            { "Down", new Vector3(-1f, 0f, 0f)},
            { "Back", new Vector3(0f, 0f, 0f)},
            { "Forward", new Vector3(0f, 0f, force)},
            { "Left", new Vector3(-force, 0f, 0f)},
            { "Right", new Vector3(force, 0f, 0f)}
        };

        targetRotation = transform.rotation;
        pivot = GameObject.FindGameObjectWithTag("PlayerPivot");
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
    void Update()
    {


        if (attractionObject == null)
        {
            return;
        }

        if (tag == "Player")
        {
            Physics.gravity = gravityRef[attractionObject.tag];

            targetRotation *= Quaternion.AngleAxis(angleRef[attractionObject.tag], rotationRef[attractionObject.tag]);

            print(targetRotation);
            pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);


            attractionObject = null;
        }
        else
        {
            //float distance = Vector3.Distance(this.transform.position, attractionObject.transform.position);
            //Debug.Log(attractionObject.transform.position);
            //Vector3 closestPoint = attractionObject.GetComponent<Collider>().ClosestPoint(this.transform.position);
            //Vector3 closestPoint = NearestVertexTo();
            Vector3 closestPoint = attractionObject.GetComponent<Collider>().bounds.ClosestPoint(this.transform.position);
            Vector3 vector = closestPoint - this.transform.position;


            this.GetComponent<Rigidbody>().AddForce(vector * force);

            targetRotation *= Quaternion.AngleAxis(60, rotationRef[attractionObject.tag]);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);


        }



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