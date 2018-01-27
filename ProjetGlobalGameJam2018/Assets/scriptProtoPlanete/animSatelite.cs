using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSatelite : MonoBehaviour
{
	private float RotateSpeed = 1f;
	private float Radius = 3.0f;

	private Vector2 _centre;
	private float _angle;

	Quaternion rotation = new Quaternion();

	private void Start() {
		_centre = transform.position;
	}

	private void Update() {
		_angle += RotateSpeed * Time.deltaTime;

		var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
		
		transform.position = _centre + offset;

		if (transform.rotation.eulerAngles.z <= -29 && transform.rotation.eulerAngles.z >= -31)
		{
			print("reposition");
		}
		
		transform.Rotate(rotation.eulerAngles = new Vector3(0, 0, -1f));
		
		print(transform.rotation.eulerAngles.z);
	}
}