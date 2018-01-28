using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFont : MonoBehaviour {

	private float _rotationSpeed = -2;
	private Vector2 _centre;
	// Use this for initialization
	void Start () {
		_centre = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0, _rotationSpeed * Time.deltaTime);
		
		transform.RotateAround(_centre, Vector3.back, 1 * Time.deltaTime);
	}
}
