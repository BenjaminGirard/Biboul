using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    int roomSizeHalf;
    public GameObject Maze;
	// Use this for initialization
	void Start () {
        roomSizeHalf = Maze.GetComponent<MazeGenerator>().roomSize / 2;
    }

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(transform.parent.position + new Vector3(roomSizeHalf, roomSizeHalf, roomSizeHalf), transform.position) >= roomSizeHalf)
        {
            List<GameObject> rooms = Maze.GetComponent<MazeGenerator>().mazeRooms;
            foreach (var room in rooms)
            {
                if (Vector3.Distance(room.transform.position + new Vector3(roomSizeHalf, roomSizeHalf, roomSizeHalf), transform.position) < roomSizeHalf)
                {
                    transform.parent = room.transform;
                    break;
                }
            }
        }
        if (!GetComponentInParent<RoomMove>().fix && GetComponent<PlayerController>().enabled)
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else if (GetComponentInParent<RoomMove>().fix && !GetComponent<PlayerController>().enabled)
        {
            GetComponent<PlayerController>().enabled = true;
        }
    }
}
