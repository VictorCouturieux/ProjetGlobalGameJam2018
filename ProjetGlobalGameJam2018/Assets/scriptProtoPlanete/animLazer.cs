using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class animLazer : MonoBehaviour
{
	private Vector3 _initialPossition;
	private int _posAlleaRottateZ;
	private Quaternion _quaternion;
	
	// Use this for initialization
	void Start ()
	{
//		_posAlleaRottateZ = Random.Range(-180, 180);
//		print(_posAlleaRottateZ);
//		transform.rotation = new Quaternion(0,0,_posAlleaRottateZ,0);
		_initialPossition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.right * Time.deltaTime);

//		print("vecteur : " + Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) 
//		      + "/ 8"
//		      + "\nposition initiale :" + _initialPossition);
		
		if ( Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) >= 8)
		{
//			_posAlleaRottateZ = Random.Range(0, 359);
//			transform.rotation = new Quaternion(0,0,_posAlleaRottateZ,0);
//			print(transform.rotation.z);
			transform.position = _initialPossition;
		}
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		print("An objet collided");
//		_posAlleaRottateZ = Random.Range(0, 359);
//		transform.rotation = new Quaternion(0,0,_posAlleaRottateZ,0);
//		print(transform.rotation.z);
		transform.position = _initialPossition;
	}
	
}
