using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable {

    public bool IsLightOn;

    public GameObject LampObject; // set in inspector

    public Color Colour_On;
    public Color Colour_Off;

    private Light _lampLight; // component on LampObject
    private SpriteRenderer _lampSpriteRender; // component on LampObject
    private AudioSource _audioSource; // component on the same gameobject as this script

    void Start () {
		_audioSource = GetComponent<AudioSource> ();
        _lampLight = LampObject.GetComponent<Light>();
        _lampSpriteRender = LampObject.GetComponent<SpriteRenderer>();
        IsLightOn = true;
	}

	public override void OnClick () {
		_audioSource.pitch = Random.Range (0.8f,1.2f);
		_audioSource.Play ();
        IsLightOn = !IsLightOn;
        AdjustLight();
	}

    void AdjustLight() {
        _lampLight.enabled = IsLightOn;

        if (IsLightOn)
        {
            _lampSpriteRender.color = Colour_On;
        }
        else {
            _lampSpriteRender.color = Colour_Off;
        }
    }
    
}
