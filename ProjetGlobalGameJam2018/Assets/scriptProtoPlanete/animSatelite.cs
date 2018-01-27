using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSatelite : MonoBehaviour
{
	private const float Min = 10f;
	private const float Max = 100f;
	
	private float rotationSpeed = 75;
	
	private Vector2 _centre;
	
	private void Start() {
		_centre = new Vector3(0, 0, 1);
	}

	
	private void Update()
	{

		
		
		if (Input.GetKey("up"))
		{
			rotationSpeed++;
			if (rotationSpeed > Max)
			{
				rotationSpeed = Max;
			}
		}
		if (Input.GetKey("down"))
		{
			rotationSpeed--;
			if (rotationSpeed < Min)
			{
				rotationSpeed = Min;
			}
		}
		
		transform.RotateAround(_centre, Vector3.back, rotationSpeed * Time.deltaTime);
		
		print(rotationSpeed);
	}
}