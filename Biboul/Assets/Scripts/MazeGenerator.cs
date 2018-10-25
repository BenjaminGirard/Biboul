using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject room;
    public int roomSize;
    public int mazeSize;

    public List<GameObject> mazeRooms = new List<GameObject>();

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

    // Use this for initialization
    void Start () {
        GenerateMazeRooms();
        //GenerateDoors();
    }
}
