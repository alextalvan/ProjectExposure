﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Image))]
public class MoneyBar : MonoBehaviour {


	Image _image;

	[SerializeField]
	Material _cutoutMaterial;

	// Use this for initialization
	void Awake () 
	{
		_image = GetComponent<Image>();
		SetCutout(0.0f);

		_image.material = (Material)Instantiate(_cutoutMaterial);
	}


	public void SetCutout(float amount)
	{
		_image.material.SetFloat("_ValueY",amount);
	}
}
