using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
	private Renderer renderer;
	private Shader normal;
	[SerializeField]
	private Shader highlightHover;
	[SerializeField]
    private Shader highlightSelected;

	private bool isSelected;
	private short clickCount;

	// Use this for initialization
	void Start ()
	{
		renderer = GetComponent<Renderer>();
		normal = Shader.Find("Diffuse");
	}

	// Update is called once per frame
	void Update ()
	{
		print(renderer.material.shader.name);
		if (Input.GetMouseButtonDown(0))
			clickCount++;
		if (clickCount == 2)
		{
			clickCount = 0;
			renderer.material.shader = normal;
			isSelected = false;
		}
	}

	void OnMouseOver()
	{
		if (!isSelected)
			renderer.material.shader = highlightHover;			
	}

    void OnMouseExit()
    {
	    if (!isSelected)
		    renderer.material.shader = normal;
    }

	void OnMouseDown()
	{
		if (!isSelected)
		{
			isSelected = true;
			renderer.material.shader = normal;
			renderer.material.shader = highlightSelected;
		}
		else
			isSelected = false;
	}
}
