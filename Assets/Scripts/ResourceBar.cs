using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
	public enum Resource { Hygiene, Hunger, Energy, Bathroom, Progress};
	public Resource resource;

	Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	void Update()
	{
		switch ((int)resource)
		{
			case 0:
				image.fillAmount = GameMaster.instance.Hygiene / 100;
				break;
			case 1:
				image.fillAmount = GameMaster.instance.Hunger / 100;
				break;
			case 2:
				image.fillAmount = GameMaster.instance.Energy / 100;
				break;
			case 3:
				image.fillAmount = GameMaster.instance.Bathroom / 100;
				break;
			case 4:
				image.fillAmount = GameMaster.instance.Progress / 100;
				break;
		}
	}
}