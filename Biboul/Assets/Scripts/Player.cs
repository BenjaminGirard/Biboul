using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (!GetComponentInParent<RoomMove>().fix && GetComponent<PlayerController>().enabled)
        {
            GetComponent<PlayerController>().enabled = false;
        }
        else if (GetComponentInParent<RoomMove>().fix && !GetComponent<PlayerController>().enabled)
        {
            GetComponent<PlayerController>().enabled = true;
        }
    }
}
