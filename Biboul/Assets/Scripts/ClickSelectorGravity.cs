using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorGravity : MonoBehaviour {

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
            if (handle.selected == null)
            {
                handle.selected = gameObject;
            }
            else
            {
                handle.selected.GetComponent<Rigidbody>().useGravity = false;
                handle.selected.GetComponent<Gravity>().attractionObject = gameObject;
                handle.ClearSelected(25);
            }
        }
    }
}
