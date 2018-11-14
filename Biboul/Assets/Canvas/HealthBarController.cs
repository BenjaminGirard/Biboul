using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	public GameObject greenBar;
    public float FadeRate;
	public Image imageBlood;
	private float targetAlpha;
	private bool active = false;
	private Image green;
	private float maxDmg = 100;
	// Use this for initialization
	void Start () {
		green = greenBar.GetComponent<Image>();
		if (green == null || imageBlood == null)
			Debug.LogError("Error: No image on " + green.name + " or in " + imageBlood.name);
		targetAlpha = imageBlood.color.a;
	}
	
	// Update is called once per frame
	void Update () {
		Color curColor = imageBlood.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);

        if (alphaDiff > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            imageBlood.color = curColor;
        }
        if (green.fillAmount == 0.0f)
            return ;
		if (active)
			green.fillAmount += Time.deltaTime / 6.0f;
        if (green.fillAmount == 1.0f)
        {
            active = false;
            targetAlpha = 0.0f;
        }
            
	}

	public void  takeDmg(float amount) {
		float dmg = amount / maxDmg;

		if (green.fillAmount < dmg){
			green.fillAmount = 0.0f;
			//gameOver;
			return ;
		}
		green.fillAmount -= dmg;
		targetAlpha = green.fillAmount * imageBlood.color.a + 1;
		if (!active)
			active = true;
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
            takeDmg(20f);
    }

    public void FadeOut() {
		targetAlpha = 0.0f;
	}
	public void FadeIn() {
		targetAlpha = 1.0f;
	}
}
