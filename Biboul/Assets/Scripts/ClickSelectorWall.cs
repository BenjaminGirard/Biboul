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
                if (handle.selected.tag == "Player")
                {
                    /*switch (plane.tag)
                    {
                        case "Down":
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(0, 0, 0, 1);
                            break;
                        case "Up":
                            Debug.Log("niquez bien");
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(1, 0, 0, 0);
                            break;
                        case "Back":
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(0.7f, 0, 0, 0.7f);
                            break;
                        case "Forward":
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(-0.7f, 0, 0, 0.7f);
                            break;
                        case "Left":
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(0, 0, -0.7f, 0.7f);
                            break;
                        case "Right":
                            handle.selected.GetComponent<PlayerController>().target = new Quaternion(0, 0, 0.7f, 0.7f);
                            break;
                    }*/
                    switch (plane.tag)
                    {
                        case "Down":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(0, 0, 0);
                            break;
                        case "Up":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(0, 0, 180);
                            break;
                        case "Back":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(90, 0, 0);
                            break;
                        case "Forward":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(-90, 0, 0);
                            break;
                        case "Left":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(0, 0, -90);
                            break;
                        case "Right":
                            handle.selected.GetComponent<PlayerController>().target = new Vector3(0, 0, 90);
                            break;
                    }
                    handle.selected.GetComponent<PlayerController>().isRotating = true;
                }
                //                handle.selected.GetComponent<Rigidbody>().useGravity = false;
                //                handle.selected.GetComponent<Rigidbody>().velocity = Vector3.zero;
                handle.selected.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                handle.selected.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
                handle.selected.GetComponent<Gravity>().attractionObject = plane;
                handle.ClearSelected(50);
            }
        }
    }
}
