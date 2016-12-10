using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
	public enum Resource { Hygiene, Hunger, Energy, Bathroom };
	public Resource resource;

	Image image;

	public GameObject resourceFrame;

	void Start()
	{
		image = GetComponent<Image>();
	}

	void Update()
	{
		switch ((int)resource)
		{
			case 0:
				image.fillAmount = GameMaster.instance.hygiene / 100;
				break;
			case 1:
				image.fillAmount = GameMaster.instance.hunger / 100;
				break;
			case 2:
				image.fillAmount = GameMaster.instance.energy / 100;
				break;
			case 3:
				image.fillAmount = GameMaster.instance.bathroom / 100;
				break;
		}
	}
}