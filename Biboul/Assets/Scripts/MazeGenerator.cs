using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject room;
    public int roomSize;
    public int mazeSize;

    List<GameObject> mazeRooms;

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

    private void DigDoor(GameObject room, Vector3 pos)
    {
        while (room.GetComponent<RoomGenerator>().roomCubes.Count < roomSize * roomSize * 2 + (roomSize - 2) * roomSize * 2 + (roomSize - 2) * (roomSize - 2) * 2)
        {
        }
        List<GameObject> cubes = room.GetComponent<RoomGenerator>().roomCubes;
        foreach (var cube in cubes)
        {
            //            UnityEngine.Debug.Log(cube.transform.localPosition);
            if (pos == cube.transform.localPosition)
            {
                UnityEngine.Debug.Log("in");
//                cubes.Remove(cube);
                GameObject.Destroy(cube);
            }
        }
    }

    private void GenerateDoors()
    {
        foreach (var room in mazeRooms)
        {
            System.Random rnd = new System.Random();
            int face = 1; //rnd.Next(1, 6);
            switch(face)
            {
                case 1:
                    DigDoor(room, new Vector3(0, roomSize / 2, roomSize / 2));                    
                    break;
                case 2:
                    DigDoor(room, new Vector3(roomSize / 2, 0, roomSize / 2));
                    break;
                case 3:
                    DigDoor(room, new Vector3(roomSize / 2, roomSize / 2, 0));
                    break;
                case 4:
                    DigDoor(room, new Vector3(roomSize - 1, roomSize / 2, roomSize / 2));
                    break;
                case 5:
                    DigDoor(room, new Vector3(roomSize / 2, roomSize - 1, roomSize / 2));
                    break;
                case 6:
                    DigDoor(room, new Vector3(roomSize / 2, roomSize / 2, roomSize - 1));
                    break;
                default:
                    break;
            }
        }
    }

    // Use this for initialization
    void Start () {
        mazeRooms = new List<GameObject>();
        GenerateMazeRooms();
        GenerateDoors();
    }
}
