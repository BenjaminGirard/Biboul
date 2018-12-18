using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorCharacter : MonoBehaviour
{

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (this.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            AttractionSelector handle = GetComponent<AttractionSelector>();
            if (handle.selected == null)
            {
                handle.selected = gameObject;
            }
        }
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
                handle.selected.GetComponent<Rigidbody>().velocity = Vector3.zero;
                handle.selected.GetComponent<Gravity>().attractionObject = gameObject;
                handle.ClearSelected(25);
            }
        }
    }
}
