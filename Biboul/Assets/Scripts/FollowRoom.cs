using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoom : MonoBehaviour {

    int roomSizeHalf;
    private GameObject maze;

    // Use this for initialization
    void Start () {
        maze = GameObject.FindGameObjectWithTag("Maze");
        roomSizeHalf = maze.GetComponent<MazeGenerator>().roomSize / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.parent.position + new Vector3(roomSizeHalf, roomSizeHalf, roomSizeHalf), transform.position) >= roomSizeHalf)
        {
            List<GameObject> rooms = maze.GetComponent<MazeGenerator>().mazeRooms;
            foreach (var room in rooms)
            {
                if (Vector3.Distance(room.transform.position + new Vector3(roomSizeHalf, roomSizeHalf, roomSizeHalf), transform.position) < roomSizeHalf)
                {
                    transform.parent = room.transform;
                    break;
                }
            }
        }
    }
}
