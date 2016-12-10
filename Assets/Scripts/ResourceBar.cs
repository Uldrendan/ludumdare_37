using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{

	RectTransform rekt;

	float originalSizeX;

	public GameObject resourceFrame;

	bool lowResource = false;

	public Color pulseColor;
	Color targetColor;

	void Start()
	{
		targetColor = pulseColor;
		rekt = this.GetComponent<RectTransform>();
		originalSizeX = rekt.sizeDelta.x;
	}

	void FixedUpdate()
	{
		rekt.sizeDelta = new Vector2(originalSizeX * (GameMaster.instance.energy / 100), rekt.sizeDelta.y); //need to make this flexible for other resource types

		if (GameMaster.instance.energy <= 20)
			lowResource = true;
		else
			lowResource = false;

		if (lowResource)
		{
			Pulse();
		}
		else if (this.GetComponent<Image>().color != Color.white)
		{
			ResetColor();
		}
	}

	void Pulse()
	{
		this.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);
		resourceFrame.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);

		if (this.GetComponent<Image>().color == targetColor)
		{
			if (targetColor == pulseColor)
				targetColor = Color.white;
			else
				targetColor = pulseColor;
		}
	}

	public void ResetColor()
	{
		this.GetComponent<Image>().color = Color.white;
		resourceFrame.GetComponent<Image>().color = Color.white;
	}
}