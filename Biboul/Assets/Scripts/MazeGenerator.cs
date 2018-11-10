using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject plane;
    public GameObject room;
    public int roomSize;
    public int mazeSize;

    public List<GameObject> mazeRooms = new List<GameObject>();

    bool doorGen = false;

    private void GenerateMazeRooms()
    {
        Vector3 pos;
        for (int x = 0; x < mazeSize; ++x)
        {
            for (int y = 0; y < mazeSize; ++y)
            {
                for (int z = 0; z < mazeSize; ++z)
                {
                    GameObject newRoom = Instantiate(room);
                    newRoom.name = "room" + (z + (y * 10) + (100 * x));
                    pos.x = x * roomSize;
                    pos.y = y * roomSize;
                    pos.z = z * roomSize;
                    newRoom.transform.parent = gameObject.transform;
                    newRoom.transform.localPosition = pos;
                    mazeRooms.Add(newRoom);
                }
            }
        }
    }

    void GeneratePlane()
    {
        float sideSize = mazeSize * roomSize;
        float center = sideSize / 2;
        GameObject newPlane;
        newPlane = Instantiate(plane);
        newPlane.name = "Left";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(-5, center, center);
        newPlane.transform.localScale = new Vector3(1, sideSize, sideSize);
        newPlane.tag = "Left";

        newPlane = Instantiate(plane);
        newPlane.name = "Right";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(sideSize + 5, center, center);
        newPlane.transform.localScale = new Vector3(1, sideSize, sideSize);
        newPlane.tag = "Right";

        newPlane = Instantiate(plane);
        newPlane.name = "Down";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(center, -5, center);
        newPlane.transform.localScale = new Vector3(sideSize, 1, sideSize);
        newPlane.tag = "Down";

        newPlane = Instantiate(plane);
        newPlane.name = "Up";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(center, sideSize + 5, center);
        newPlane.transform.localScale = new Vector3(sideSize, 1, sideSize);
        newPlane.tag = "Up";

        newPlane = Instantiate(plane);
        newPlane.name = "Back";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(center, center, -5);
        newPlane.transform.localScale = new Vector3(sideSize, sideSize, 1);
        newPlane.tag = "Back";

        newPlane = Instantiate(plane);
        newPlane.name = "Forward";
        newPlane.transform.parent = gameObject.transform;
        newPlane.transform.localPosition = new Vector3(center, center, sideSize + 5);
        newPlane.transform.localScale = new Vector3(sideSize, sideSize, 1);
        newPlane.tag = "Forward";
    }

    // Use this for initialization
    void Start () {
        GeneratePlane();
        GenerateMazeRooms();
        //GenerateDoors();
    }

    private void Update()
    {
        if (!doorGen && mazeRooms.Count != 0)
        {
            System.Random rnd = new System.Random();

            foreach (var room in mazeRooms)
            {
                room.GetComponent<RoomGenerator>().GenerateDoor(rnd.Next(1, 6));
            }
            doorGen = true;
        }
    }
}
