using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject Transmission;
    public int score;
    float tempo;
    public Text ScoreText;
    public Text MsgFailText;

    public List<GameObject> ListSatelite;

    public string[] MsgFail;

    public bool GameIsOn;

	private Color _colorLight;
	private Color _colorNoLight;

	private int _pushKey ;
	
	// Use this for initialization
	void Start () {
        MsgFailText.text = "";
        _pushKey = 1;

        _colorLight = new Color(255,255,255, 1);
		_colorNoLight = new Color(255, 255, 255, 0.65f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameIsOn) {
            SelectSatellite();
        }
	}

    public void LaunchGame() {
        GameIsOn = true;
        InvokeRepeating("SpawnRandom", 2.0f, 3.0f);
    }
	
	public void SelectSatellite()
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
		
	}
	
	public void SpawnRandom() {
		Instantiate(Transmission, new Vector3(0,0,0.1f), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward));
	}

    public void addScore() {
        score++;
        ScoreText.text = "SCORE " + score;
        //TODO: Add CatchSound here
    }

    public void lossScore() {
        score--;
        ScoreText.text = "SCORE " + score;
        addMsgFailed();
        //TODO: Add ShowMsgSound Here (Loss)
    }

    public void addMsgFailed() {
        MsgFailText.text = "- " + MsgFail[Random.Range(0, MsgFail.Length)] + "\n\n" + MsgFailText.text;
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
        GameManager mySecondScript = (GameManager)target;
        if (GUILayout.Button("Bad Newzz !")) {
            mySecondScript.addMsgFailed();
        }
    }
}