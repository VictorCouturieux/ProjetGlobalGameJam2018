using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject Transmission;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SpawnRandom() {
		Instantiate(Transmission, Vector3.zero, Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward)); //Object Socks = 
	}
	
}
