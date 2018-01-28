using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlaySound : MonoBehaviour
{

	public AudioClip AudioClip;
	
	public AudioSource Source;
	
	// Use this for initialization
	void Start () {
		
//		_source = GetComponent<AudioSource>();
		
		Source.PlayOneShot(AudioClip,3F);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
