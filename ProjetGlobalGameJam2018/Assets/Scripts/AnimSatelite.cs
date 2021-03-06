﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimSatelite : MonoBehaviour
{
	private const float Min = 5f;
	private const float Max = 90f;
	
	private float _rotationSpeed;
	public int CoeffRotation;
	
	private Vector2 _centre;

	private void Start() {
		_centre = new Vector3(0, 0, 1);
		
		_rotationSpeed = Random.Range(Min, Max);

		try
		{
			if (CoeffRotation != -1 && CoeffRotation != 1)
				throw new Exception("La valeur du coeff Rotation ne peut etre que -1 ou 1");
		}
		catch (Exception e)
		{
			print("erreur de generation de Satelite : " + e);
		}
	}

	
	private void Update()
	{

		transform.RotateAround(_centre, Vector3.back, CoeffRotation * _rotationSpeed * Time.deltaTime);
		
//		print(rotationSpeed);
	}

	public void RotationSpeed()
	{
		if (Input.GetKey("up"))
		{
			_rotationSpeed+=3;
			if (_rotationSpeed > Max)
			{
				_rotationSpeed = Max;
			}
		}
		if (Input.GetKey("down"))
		{
			_rotationSpeed-=3;
			if (_rotationSpeed < Min)
			{
				_rotationSpeed = Min;
			}
		}
	}
	
	
	public float GetRotationSpeed()
	{
		return _rotationSpeed;
	}
	public void SetRotationSpeed( float _rotationSpeed)
	{
		this._rotationSpeed = _rotationSpeed;
	}
	public float GetMin()
	{
		return Min;
	}
	public float GetMax()
	{
		return Max;
	}
	
	
}