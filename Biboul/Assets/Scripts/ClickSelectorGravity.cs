using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectorGravity : MonoBehaviour {

    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        print("update");
        if (Input.GetKeyDown(KeyCode.F)) {
            print("keypressed");

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

    private void OnMouseOver()
    {
        print(gameObject.tag);
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
