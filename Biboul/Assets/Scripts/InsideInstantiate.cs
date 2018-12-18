using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideInstantiate : MonoBehaviour {

    public GameObject drone;
    public GameObject cube;
    int roomSize;
    public List<GameObject> ennemies = new List<GameObject>();
    public List<GameObject> cubes = new List<GameObject>();
    // Use this for initialization
    void Start () {
        Random.InitState(System.DateTime.Now.Millisecond);

        roomSize = gameObject.GetComponentInParent<MazeGenerator>().roomSize;
        int rnd = Random.Range(0, 2);
        if (rnd == 1)
        {
            GameObject newDrone = Instantiate(drone);
            newDrone.transform.parent = transform;
            newDrone.GetComponent<DroneBehavior>().target = GameObject.FindGameObjectWithTag("Player");
            newDrone.transform.localPosition = new Vector3(roomSize / 2, roomSize / 2, roomSize / 2);
            ennemies.Add(newDrone);

            GameObject newCube = Instantiate(cube);
            newCube.transform.parent = transform;
            newCube.transform.localPosition = new Vector3(roomSize / 2, roomSize / 2, roomSize / 2);
            cubes.Add(newCube);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
