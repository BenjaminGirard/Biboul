using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public GameObject cube;
    public int size;

    public List<GameObject> roomCubes;

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

    // Use this for initialization
    void Start () {
        roomCubes = new List<GameObject>();

        GenerateRoomCubes();
	}
}
