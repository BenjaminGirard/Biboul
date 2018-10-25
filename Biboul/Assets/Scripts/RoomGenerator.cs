using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public GameObject cube;
    public int size;

    public List<GameObject> roomCubes = new List<GameObject>();
    List<int> tempDoor = new List<int>();

    public void AddDoor(int face)
    {
        tempDoor.Add(face);
    }

    private void GenerateRoomCubes()
    {
        Vector3 pos;
        for (pos.x = 0; pos.x < size; ++pos.x)
        {
            for (pos.y = 0; pos.y < size; ++pos.y)
            {
                for (pos.z = 0; pos.z < size; ++pos.z)
                {
                    if (pos.z == 0 || pos.x == 0 || pos.y == 0 || pos.x == size - 1 || pos.y == size - 1 || pos.z == size - 1)
                    {
                        roomCubes.Add(Instantiate(cube) as GameObject);
                        roomCubes[roomCubes.Count - 1].name = "cube" + (pos.z + (pos.y * 10) + (100 * pos.x));
                        roomCubes[roomCubes.Count - 1].transform.parent = gameObject.transform;
                        roomCubes[roomCubes.Count - 1].transform.localPosition = pos;
                    }
                }
            }
        }
    }

    private void DigDoor(Vector3 pos)
    {
        foreach (var cube in roomCubes)
        {
            //            UnityEngine.Debug.Log(cube.transform.localPosition);
            if (pos == cube.transform.localPosition)
            {
                roomCubes.Remove(cube);
                Destroy(cube);
                break;
            }
        }
    }
   
    private void DigSide(int face, Vector3 sidePos)
    {
        List<GameObject> rooms = gameObject.GetComponentInParent<MazeGenerator>().mazeRooms;

        foreach (var room in rooms)
        {
            if (sidePos == room.transform.localPosition)
            {
                room.GetComponent<RoomGenerator>().AddDoor(face);
            }
        }
    }

    private void GenerateDoor(int face)
    {
        Vector3 posit = this.transform.localPosition;
        switch (face)
        {
            case 1:
                DigDoor(new Vector3(0, size / 2, size / 2));
                DigSide(4, new Vector3(posit.x - size, posit.y, posit.z));
                break;
            case 2:
                DigDoor(new Vector3(size / 2, 0, size / 2));
                DigSide(5, new Vector3(posit.x, posit.y - size, posit.z));
                break;
            case 3:
                DigDoor(new Vector3(size / 2, size / 2, 0));
                DigSide(6, new Vector3(posit.x, posit.y, posit.z - size));
                break;
            case 4:
                DigDoor(new Vector3(size - 1, size / 2, size / 2));
                DigSide(1, new Vector3(posit.x + size, posit.y, posit.z));
                break;
            case 5:
                DigDoor(new Vector3(size / 2, size - 1, size / 2));
                DigSide(2, new Vector3(posit.x, posit.y + size, posit.z));
                break;
            case 6:
                DigDoor(new Vector3(size / 2, size / 2, size - 1));
                DigSide(3, new Vector3(posit.x, posit.y, posit.z + size));
                break;
            default:
                break;
        }
    }

    private void GenerateTmpDoor(int face)
    {
        switch (face)
        {
            case 1:
                DigDoor(new Vector3(0, size / 2, size / 2));
                break;
            case 2:
                DigDoor(new Vector3(size / 2, 0, size / 2));
                break;
            case 3:
                DigDoor(new Vector3(size / 2, size / 2, 0));
                break;
            case 4:
                DigDoor(new Vector3(size - 1, size / 2, size / 2));
                break;
            case 5:
                DigDoor(new Vector3(size / 2, size - 1, size / 2));
                break;
            case 6:
                DigDoor(new Vector3(size / 2, size / 2, size - 1));
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        GenerateRoomCubes();
        System.Random rnd = new System.Random();
        int face = rnd.Next(1, 6);
        GenerateDoor(face);
	}

    void Update()
    {
        foreach (var tmp in tempDoor)
        {
            GenerateTmpDoor(tmp);
        }
    }
}
