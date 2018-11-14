using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public GameObject cube;

    GameObject player;
    float size;
    bool display = false;
    float distancePlayer;

    public List<GameObject> roomCubes = new List<GameObject>();
    List<int> doors = new List<int>();

    public bool IsDoor(int face)
    {
        foreach(var door in doors)
        {
            if (door == face)
                return true;
        }
        return false;
    }

    private void GenerateRoomCubes()
    {
        Vector3 pos;
        GameObject tmpCube;

        for (pos.x = 0; pos.x < size; ++pos.x)
        {
            for (pos.y = 0; pos.y < size; ++pos.y)
            {
                for (pos.z = 0; pos.z < size; ++pos.z)
                {
                    if (pos.x == 0 || pos.y == 0 || pos.z == 0 || pos.x == size - 1 || pos.y == size - 1 || pos.z == size - 1)
                    {
                        tmpCube = Instantiate(cube);
                        tmpCube.name = "cube" + (pos.z + (pos.y * 10) + (100 * pos.x));
                        tmpCube.transform.parent = gameObject.transform;
                        tmpCube.transform.localPosition = pos;
                        tmpCube.SetActive(false);
                        if (pos.x == 0)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Left");
                        else if (pos.y == 0)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Down");
                        else if (pos.z == 0)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Back");
                        else if (pos.x == size - 1)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Right");
                        else if (pos.y == size - 1)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Up");
                        else if (pos.z == size - 1)
                            tmpCube.GetComponent<ClickSelectorWall>().plane = GameObject.FindGameObjectWithTag("Forward");
                        roomCubes.Add(tmpCube);
                    }
                }
            }
        }
    }

    private void DigDoor(Vector3 pos)
    {
        for (int i = roomCubes.Count - 1; i >= 0; i--)
        {
            //            UnityEngine.Debug.Log(cube.transform.localPosition);
            if (Vector3.Distance(pos, roomCubes[i].transform.localPosition) < 1.5f)
            {
                Destroy(roomCubes[i]);
                roomCubes.RemoveAt(i);
                //break;
            }
        }
    }
   
    private void DigTmpDoor(Vector3 pos)
    {
        foreach (var cube in roomCubes)
        {
            //            UnityEngine.Debug.Log(cube.transform.localPosition);
            if (Vector3.Distance(pos, cube.transform.localPosition) < 1.5f)
            {
                cube.SetActive(false);
                //break;
            }
        }
    }

    public void GenerateDoor(int face)
    {
        doors.Add(face);
        Vector3 posit = this.transform.localPosition;
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

    private bool CheckTmpDoor(int face, Vector3 sidePos)
    {
        if (face < 4)
            face += 3;
        else
            face -= 3;
        List<GameObject> rooms = gameObject.GetComponentInParent<MazeGenerator>().mazeRooms;
        foreach (var room in rooms)
        {
            if (room.transform.localPosition == sidePos)
            {
                if (room.GetComponent<RoomGenerator>().IsDoor(face))
                {
                    return true;
                }
                break;
            }
        }
        return false;
    }

    private void HandleTmpDoor(int face)
    {
        Vector3 posit = this.transform.localPosition;
        switch (face)
        {
            case 1:
                if (CheckTmpDoor(face, new Vector3(posit.x - size, posit.y, posit.z)))
                    DigTmpDoor(new Vector3(0, size / 2, size / 2));
                break;
            case 2:
                if (CheckTmpDoor(face, new Vector3(posit.x, posit.y - size, posit.z)))
                    DigTmpDoor(new Vector3(size / 2, 0, size / 2));
                break;
            case 3:
                if (CheckTmpDoor(face, new Vector3(posit.x, posit.y, posit.z - size)))
                    DigTmpDoor(new Vector3(size / 2, size / 2, 0));
                break;
            case 4:
                if (CheckTmpDoor(face, new Vector3(posit.x + size, posit.y, posit.z)))
                    DigTmpDoor(new Vector3(size - 1, size / 2, size / 2));
                break;
            case 5:
                if (CheckTmpDoor(face, new Vector3(posit.x, posit.y + size, posit.z)))
                    DigTmpDoor(new Vector3(size / 2, size - 1, size / 2));
                break;
            case 6:
                if (CheckTmpDoor(face, new Vector3(posit.x, posit.y, posit.z + size)))
                    DigTmpDoor(new Vector3(size / 2, size / 2, size - 1));
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        size = gameObject.GetComponentInParent<MazeGenerator>().roomSize;
        GenerateRoomCubes();
	}

    public void Deactivate()
    {
        foreach (var cube in roomCubes)
            cube.SetActive(false);
        display = false;
    }

    public void Activate()
    {
        foreach (var cube in roomCubes)
            cube.SetActive(true);
        display = true;
 
        for (int i = 1; i < 7; ++i)
        {
            HandleTmpDoor(i);
        }
    }

    void Update()
    {
        distancePlayer = Vector3.Distance(player.transform.position, this.transform.position + new Vector3(size / 2, size / 2, size / 2));
        if (display &&  distancePlayer > 2 * size)
        {
            Deactivate();
        }
        if (!display && distancePlayer <= 2 * size)
        {
            Activate();
        }
    }
}
