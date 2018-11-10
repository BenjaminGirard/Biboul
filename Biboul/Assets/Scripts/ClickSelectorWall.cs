using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorWall : MonoBehaviour {

    public GameObject plane;
    private GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttractionSelector handle = mainCamera.GetComponent<AttractionSelector>();
            if (handle.selected != null)
            {
                handle.selected.GetComponent<Rigidbody>().useGravity = false;
                handle.selected.GetComponent<Gravity>().attractionObject = plane;
                handle.selected = null;
            }
        }
    }
}
