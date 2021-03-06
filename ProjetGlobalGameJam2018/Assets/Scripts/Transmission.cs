﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {
//	private Vector3 _initialPossition;
	private int _posAlleaRottateZ;
	private Quaternion _quaternion;
    private GameManager GM_;
	
	
	// Use this for initialization
	void Start ()
	{
        //		_initialPossition = transform.position;
        GM_ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.right * 0.75f * Time.deltaTime);

//		print("vecteur : " + Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) 
//		      + "/ 8"
//		      + "\nposition initiale :" + _initialPossition);
		
		if ( Math.Sqrt( Math.Pow(transform.position.x , 2) + Math.Pow(transform.position.y , 2)) >= 6)
		{
//			transform.position = _initialPossition;
			GM_.PlayMsgNonCapt();
			Destroy(this.gameObject);
            GM_.lossScore();
        }
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		print("An objet collided");
		GM_.PlayMsgCapt();
//		transform.position = _initialPossition;
        Destroy(this.gameObject);
        GM_.addScore();
    }
}
