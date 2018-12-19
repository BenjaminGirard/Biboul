using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
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
		normal = Shader.Find("Diffuse");
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
			clickCount++;
		if (clickCount == 2)
		{
			clickCount = 0;
			changeShaderRecursive(transform, normal);
			isSelected = false;
		}
	}

	void OnMouseOver()
	{
		if (!isSelected)
			changeShaderRecursive(transform, highlightHover);
	}

    void OnMouseExit()
    {
	    if (!isSelected)
		    changeShaderRecursive(transform, normal);
    }

	void OnMouseDown()
	{
		if (!isSelected)
		{
			isSelected = true;
			changeShaderRecursive(transform, highlightSelected);
		}
		else
			isSelected = false;
	}

	private void changeShaderRecursive(Transform parent, Shader shader)
	{
		Renderer renderer = parent.GetComponent<Renderer>();
		if (renderer)
		{
			renderer.material.shader = shader;
		}
		foreach(Transform child in parent)
		{
			changeShaderRecursive(child, shader);
		}
	}
}
