using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionSelector : MonoBehaviour {
    public GameObject selected;

    public void ClearSelected(float amount)
    {
        selected = null;
        gameObject.GetComponent<AngerBarController>().useAnger(amount);
    }
}
