using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMove : MonoBehaviour {
    float size;
    // Use this for initialization
    void Start()
    {
        size = gameObject.GetComponent<MazeGenerator>().roomSize;
        InvokeRepeating("MoveMaze", 30f, 120f);
    }

    // Update is called once per frame
    void MoveMaze()
    {
        List<GameObject> rooms = gameObject.GetComponent<MazeGenerator>().mazeRooms;

        foreach (var room in rooms)
        {
            if ((room.transform.position.y / size) % 2 == 0 && (room.transform.position.z / size) % 2 == 0)
                room.GetComponent<RoomMove>().SetNewPosition(new Vector3(size, 0, 0));
            if ((room.transform.position.x / size) % 2 == 0 && (room.transform.position.z / size) % 2 != 0)
                room.GetComponent<RoomMove>().SetNewPosition(new Vector3(0, size, 0));
            if ((room.transform.position.x / size) % 2 != 0 && (room.transform.position.y / size) % 2 != 0)
                room.GetComponent<RoomMove>().SetNewPosition(new Vector3(0, 0, size));
        }
    }

}
