using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject cube;

    List<GameObject> mazeCubes;
	// Use this for initialization
	void Start () {
        mazeCubes = new List<GameObject>();
        GameObject newCube;
        Vector3 pos;
        for (int x = 0; x < 10; ++x)
        {
            for (int y = 0; y < 10; ++y)
            {
                for (int z = 0; z < 10; ++z)
                {
                    if (z == 0 || x == 0 || y == 0 || x == 9 || y == 9 || z == 9)
                    {
                        newCube = Instantiate(cube);
                        newCube.name = "cube" + (z + (y * 10) + (100 * x));
                        pos.x = x;
                        pos.y = y;
                        pos.z = z;
                        newCube.transform.position = pos;
                        mazeCubes.Add(newCube);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
