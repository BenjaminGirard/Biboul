using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideInstantiate : MonoBehaviour {

    public GameObject drone;
    public GameObject cube;
    int roomSize;
    List<GameObject> ennemies = new List<GameObject>();
    List<GameObject> cubes = new List<GameObject>();
    // Use this for initialization
    void Start () {
        roomSize = gameObject.GetComponentInParent<MazeGenerator>().roomSize;
        GameObject newDrone = Instantiate(drone);
        newDrone.transform.parent = transform;
        newDrone.GetComponent<DroneBehavior>().target = GameObject.FindGameObjectWithTag("Player").transform;
        newDrone.transform.localPosition = new Vector3(roomSize / 2, roomSize / 2, roomSize / 2);
        ennemies.Add(newDrone);

        GameObject newCube = Instantiate(cube);
        newCube.transform.parent = transform;
        newCube.transform.localPosition = new Vector3(roomSize / 2, roomSize / 2, roomSize / 2);
        cubes.Add(newCube);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
