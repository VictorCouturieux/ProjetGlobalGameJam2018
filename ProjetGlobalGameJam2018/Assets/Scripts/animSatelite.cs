using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSatelite : MonoBehaviour
{
	private const float Min = 10f;
	private const float Max = 100f;
	
	private float _rotationSpeed = 50;
	
	private Vector2 _centre;

	private void Start() {
		_centre = new Vector3(0, 0, 1);
	}

	
	private void Update()
	{

		if (Input.GetKey("up"))
		{
			_rotationSpeed++;
			if (_rotationSpeed > Max)
			{
				_rotationSpeed = Max;
			}
		}
		if (Input.GetKey("down"))
		{
			_rotationSpeed--;
			if (_rotationSpeed < Min)
			{
				_rotationSpeed = Min;
			}
		}
		
		transform.RotateAround(_centre, Vector3.back, _rotationSpeed * Time.deltaTime);
		
//		print(rotationSpeed);
	}

	
}