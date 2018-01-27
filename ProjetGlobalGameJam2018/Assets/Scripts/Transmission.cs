using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {
//	private Vector3 _initialPossition;
	private int _posAlleaRottateZ;
	private Quaternion _quaternion;
	
	// Use this for initialization
	void Start ()
	{
//		_initialPossition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.right * Time.deltaTime);

//		print("vecteur : " + Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) 
//		      + "/ 8"
//		      + "\nposition initiale :" + _initialPossition);
		
		if ( Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) >= 8)
		{
//			transform.position = _initialPossition;
			Destroy(this);
		}
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		print("An objet collided");
//		transform.position = _initialPossition;
        Destroy(this.gameObject);
    }
}
