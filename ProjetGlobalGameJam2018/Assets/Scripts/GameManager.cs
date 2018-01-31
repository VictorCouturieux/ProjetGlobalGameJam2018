using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject Transmission;
    public int score = 0;
    public int chaosLvl = 0;
	
    int _tempo =1;
	private int _spown = 0;
	private float _vitesseSpown = 1.5f;
	
	static float delayPeriod = 1.0f; //1 seconds
	private float currentTime = 0;
	
    public Text ScoreText;
    public Text MsgFailText;
    public Text ChaosLvlText;
    public Text GameOverScoreText;

    public List<GameObject> ListSatelite;
	public List<GameObject> ListCercleSatelite;

    public string[] MsgFail;

    public bool GameIsOn;
    public bool TutorialIsOn = false;

    private Color _colorLight;
	private Color _colorNoLight;

	private int _pushKey ;

    public ShowPanels PanelsManager;
	
	
	public AudioClip AudioMsgCapt;
	public AudioClip AudioMsgNonCapt;
	
	public AudioSource Source;

	void Setup()
	{
		currentTime = Time.time + delayPeriod;
	}
	
    // Use this for initialization
    void Start () {
        MsgFailText.text = "";
        ChaosLvlText.text = "CHAOS 0%";
        _pushKey = 1;

        _colorLight = new Color( 1, 1, 1, 1);
		_colorNoLight = new Color(0.45f, 0.76f, 1f, 0.4f);
    }

	
	
	
	// Update is called once per frame
	void Update () {
        if (GameIsOn || TutorialIsOn) {
            SelectSatellite();
        }
	}

    public void LaunchGame() {
        GameIsOn = true;
	    
        InvokeRepeating("SpawnRandom", 2.0f, _vitesseSpown);

//		    Invoke("SpawnRandom", 2.0f);
	    
    }
	
    public void ResetSatellite() {
        ListCercleSatelite[0].GetComponent<SpriteRenderer>().color = _colorNoLight;
        ListCercleSatelite[1].GetComponent<SpriteRenderer>().color = _colorNoLight;
        ListCercleSatelite[2].GetComponent<SpriteRenderer>().color = _colorNoLight;
        ListCercleSatelite[3].GetComponent<SpriteRenderer>().color = _colorNoLight;
    }

	public void SelectSatellite()
	{

        ResetSatellite();


        if (Input.GetKey(KeyCode.Alpha1) || _pushKey == 1) 
		{
			_pushKey = 1;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListCercleSatelite[0].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha2) || _pushKey == 2)
		{
			_pushKey = 2;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListCercleSatelite[1].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha3) || _pushKey == 3)
		{
			_pushKey = 3;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListCercleSatelite[2].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		if (Input.GetKey(KeyCode.Alpha4) || _pushKey == 4)
		{
			_pushKey = 4;
			ListSatelite[_pushKey-1].GetComponent<AnimSatelite>().RotationSpeed();
			
			ListCercleSatelite[3].GetComponent<SpriteRenderer>().color = _colorLight;
			
//			print(_pushKey);
		}
		
	}
	
	public void SpawnRandom()
	{
		
		print(Time.time);
		_spown++;
		if (_spown == _tempo)
		{
			_vitesseSpown -= 0.5f;

			if (_vitesseSpown <= 0.25)
			{
				_vitesseSpown = 0.25f;
			}
			
			_spown = 0;
		}
//		print(_vitesseSpown);
		
		Instantiate(Transmission, new Vector3(0,0,0.1f), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward));
	}

    public void addScore() {
        score++;
        ScoreText.text = "SCORE " + score;

        chaosLvl -= 5;

        if (chaosLvl < 0) {
            chaosLvl = 0;
        }

        ChaosLvlText.text = "CHAOS " + chaosLvl + "%";
        //TODO: Add CatchSound here
    }

    public void lossScore() {
        chaosLvl += 15;
        ChaosLvlText.text = "CHAOS " + chaosLvl + "%";
        addMsgFailed();

        if (chaosLvl >= 100) {
            GameIsOn = false;
            CancelInvoke();
            ResetSatellite();
            PanelsManager.HideSatellites();
            PanelsManager.ShowLogoGGJ();
            GameOverScoreText.text = "You scored " + score + " points !";
            PanelsManager.ShowGameOverPanel();
        }
        //TODO: Add ShowMsgSound Here (Loss)
    }

    public void addMsgFailed() {
        MsgFailText.text = "- " + MsgFail[Random.Range(0, MsgFail.Length)] + "\n\n" + MsgFailText.text;
    }

    public void ActiveTutorial() {
        TutorialIsOn = !TutorialIsOn;
    }

    public void ResetGame() {
        score = 0;
        chaosLvl = 0;
        ChaosLvlText.text = "CHAOS " + chaosLvl + "%";
        ScoreText.text = "SCORE " + score;
        PanelsManager.ShowSatellites();
        MsgFailText.text = "";
    }
	
	public void PlayMsgNonCapt(){
		Source.PlayOneShot(AudioMsgNonCapt,0.7F);
	}
	
	public void PlayMsgCapt(){
		Source.PlayOneShot(AudioMsgCapt,0.7F);
	}
	
}