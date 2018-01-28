using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject Transmission;
    public int score;
    float tempo;
	
	
	public List<GameObject> ListSatelite;

	private Color _colorLight;
	private Color _colorNoLight;

	private int _pushKey ;
	
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnRandom", 2.0f, 3.0f);
		
		_colorLight = new Color(255,255,255, 1);
		_colorNoLight = new Color(255, 255, 255, 0.65f);
    }
	
	// Update is called once per frame
	void Update () {
		SelectSatelite();
	}
	
	
	public void SelectSatelite()
	{
		ListSatelite[0].GetComponent<SpriteRenderer>().color = _colorNoLight;
		ListSatelite[1].GetComponent<SpriteRenderer>().color = _colorNoLight;
		ListSatelite[2].GetComponent<SpriteRenderer>().color = _colorNoLight;
		ListSatelite[3].GetComponent<SpriteRenderer>().color = _colorNoLight;
		
		if (Input.GetKey(KeyCode.Alpha1) || _pushKey == 1) 
		{
			_pushKey = 1;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListSatelite[0].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha2) || _pushKey == 2)
		{
			_pushKey = 2;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListSatelite[1].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha3) || _pushKey == 3)
		{
			_pushKey = 3;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListSatelite[2].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha4) || _pushKey == 4)
		{
			_pushKey = 4;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListSatelite[3].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		
//		print(ListSatelite[0].GetComponent<SpriteRenderer>().color);
//		print(ListSatelite[1].GetComponent<SpriteRenderer>().color);
//		print(ListSatelite[2].GetComponent<SpriteRenderer>().color);
//		print(ListSatelite[3].GetComponent<SpriteRenderer>().color);
		
	}
	
	public void SpawnRandom() {
		Instantiate(Transmission, new Vector3(0,0,0.1f), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward));
	}

    public void addScore() {
        score++;
    }
	
}

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        GameManager myScript = (GameManager)target;
        if (GUILayout.Button("Instanciate !")) {
            myScript.SpawnRandom();
        }
    }
}