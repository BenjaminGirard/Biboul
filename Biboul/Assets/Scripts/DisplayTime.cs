using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float time = PlayerPrefs.GetFloat("Time");
        if (time == 0)
        {
            GetComponent<Text>().text = "Hey wait you lost...";
        }
        else
        {
            GetComponent<Text>().text = time + "  s";
        }
    }

}
