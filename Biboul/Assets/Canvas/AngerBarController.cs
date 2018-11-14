using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBarController : MonoBehaviour {

	public GameObject yellowBar;
	private bool active = false;
	private Image yellow;
	private float maxAnger = 100;
	// Use this for initialization
	void Start () {
		yellow = yellowBar.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
			yellow.fillAmount += Time.deltaTime / 12.0f;
		if (yellow.fillAmount == 1.0f)
			active = false;
	}

	public void useAnger(float amount) {
		float toDump = amount / maxAnger;

		if (yellow.fillAmount < toDump)
			return ;
		yellow.fillAmount -= toDump;
		if (!active)
			active = true;
	}
}
