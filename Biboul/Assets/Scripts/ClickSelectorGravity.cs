using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorGravity : MonoBehaviour {

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
            if (handle.selected == null)
            {
                handle.selected = gameObject;
            }
            else
            {
                handle.selected.GetComponent<Rigidbody>().useGravity = false;
                handle.selected.GetComponent<Gravity>().attractionObject = gameObject;
                handle.selected = null;
            }
        }
    }
}
