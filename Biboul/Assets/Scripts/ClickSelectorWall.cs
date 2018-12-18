using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorWall : MonoBehaviour {

    public GameObject plane;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttractionSelector handle = player.GetComponent<AttractionSelector>();
            if (handle.selected != null)
            {
                handle.selected.GetComponent<Rigidbody>().useGravity = false;
                handle.selected.GetComponent<Rigidbody>().velocity = Vector3.zero;
                handle.selected.GetComponent<Gravity>().attractionObject = plane;
                handle.ClearSelected(50);
            }
        }
    }
}
