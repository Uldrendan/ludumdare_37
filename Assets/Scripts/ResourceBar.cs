using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{

	Image image;

	public GameObject resourceFrame;

	bool lowResource = false;

	public Color pulseColor;
	Color targetColor;

	void Start()
	{
		targetColor = pulseColor;
		image = GetComponent<Image>();
	}

	void FixedUpdate()
	{
		image.fillAmount = GameMaster.instance.energy / 100; //need to make this flexible for other resource types

		if (GameMaster.instance.energy <= 20)
			lowResource = true;
		else
			lowResource = false;

		if (lowResource)
		{
			Pulse();
		}
		else if (GetComponent<Image>().color != Color.white)
		{
			ResetColor();
		}
	}

	void Pulse()
	{
		GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);
		resourceFrame.GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, targetColor, 20 * Time.deltaTime);

		if (GetComponent<Image>().color == targetColor)
		{
			if (targetColor == pulseColor)
				targetColor = Color.white;
			else
				targetColor = pulseColor;
		}
	}

	public void ResetColor()
	{
		GetComponent<Image>().color = Color.white;
		resourceFrame.GetComponent<Image>().color = Color.white;
	}
}