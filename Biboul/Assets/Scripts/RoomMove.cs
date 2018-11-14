using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {

    int sideSize;
    float t = 0;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 0f;
    Vector3 position;
    public bool fix = true;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.localPosition;
        target = transform.localPosition;
        sideSize = GetComponentInParent<MazeGenerator>().roomSize * (GetComponentInParent<MazeGenerator>().mazeSize - 1);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.localPosition;
        if (position != target)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.localPosition = Vector3.Lerp(startPosition, target, t);
            fix = false;
        }
        else if (!fix)
        {
            if (position.x < 0)
            {
                position.x = sideSize;
            }
            else if (position.x > sideSize)
            {
                position.x = 0;
            }
            else if (position.y < 0)
            {
                position.y = sideSize;
            }
            else if (position.y > sideSize)
            {
                position.y = 0;
            }
            else if (position.z < 0)
            {
                position.z = sideSize;
            }
            else if (position.z > sideSize)
            {
                position.z = 0;
            }
            transform.localPosition = position;
            target = position;
            gameObject.GetComponent<RoomGenerator>().Deactivate();
            fix = true;
        }
    }

    public void SetNewPosition(Vector3 newPos)
    {
        startPosition = transform.localPosition;
        target = startPosition + newPos;
        timeToReachTarget = 5f;
        t = 0f;
    }
}
