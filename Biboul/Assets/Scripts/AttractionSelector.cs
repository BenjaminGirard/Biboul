using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionSelector : MonoBehaviour {

    public GameObject selected;

    private void Start()
    {
        selected = null;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
