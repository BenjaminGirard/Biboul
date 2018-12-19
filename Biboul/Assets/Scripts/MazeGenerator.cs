using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject player;
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

    void InstantiatePlane(string type, Vector3 pos, Vector3 scale)
    {
        GameObject newPlane = GameObject.FindGameObjectWithTag(type);
        newPlane.transform.localPosition = pos;
        newPlane.transform.localScale = scale;
    }

    void GeneratePlane()
    {
        float sideSize = mazeSize * roomSize;
        float center = sideSize / 2;

        InstantiatePlane("Left", new Vector3(-roomSize, center, center), new Vector3(1, sideSize, sideSize));
        InstantiatePlane("Right", new Vector3(sideSize + roomSize, center, center), new Vector3(1, sideSize, sideSize));

        InstantiatePlane("Down", new Vector3(center, -roomSize, center), new Vector3(sideSize, 1, sideSize));
        InstantiatePlane("Up", new Vector3(center, sideSize + roomSize, center), new Vector3(sideSize, 1, sideSize));

        InstantiatePlane("Back", new Vector3(center, center, -roomSize), new Vector3(sideSize, sideSize, 1));
        InstantiatePlane("Forward", new Vector3(center, center, sideSize + roomSize), new Vector3(sideSize, sideSize, 1));
    }

    // Use this for initialization
    void Start () {
        Random.InitState(System.DateTime.Now.Millisecond);
        player.transform.localPosition = new Vector3((roomSize * mazeSize) / 2, (roomSize * mazeSize) / 2, (roomSize * mazeSize) / 2);
        GeneratePlane();
        GenerateMazeRooms();
        //GenerateDoors();
    }

    private void Update()
    {
        if (!doorGen && mazeRooms.Count != 0)
        {
            foreach (var room in mazeRooms)
            {
                room.GetComponent<RoomGenerator>().GenerateDoor(Random.Range(1, 7));
                room.GetComponent<RoomGenerator>().GenerateDoor(Random.Range(1, 7));
            }
            doorGen = true;
        }
    }
}
