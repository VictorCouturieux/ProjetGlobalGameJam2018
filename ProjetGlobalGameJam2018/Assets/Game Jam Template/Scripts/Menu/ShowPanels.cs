using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel
    public GameObject gameUIPanel;
    public GameObject helpPanel;
    public GameObject gameOverPanel;
    public GameObject creditsPanel;
    public GameObject satellites;
    public GameObject logoGlobalGameJam;

    private GameObject activePanel;                         
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;

    private GameManager GM_;

    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    public void Start()
    {
        SetSelection(menuPanel);
        GM_ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		//optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(optionsPanel);

    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        gameUIPanel.SetActive(false);
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        //optionsTint.SetActive(false);
    }

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
        print("Show Menu");
        gameUIPanel.SetActive(false);
        menuPanel.SetActive (true);
        SetSelection(menuPanel);
    }

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
        print("Hide Menu");
        menuPanel.SetActive (false);
        gameUIPanel.SetActive(true);
        GM_.LaunchGame();
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowHelpPanel() {
        helpPanel.SetActive(true);
        menuPanel.SetActive(false);
        //SetSelection(optionsPanel);
    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideHelpPanel() {
        helpPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    //Call this function to activate and display the Pause panel during game play
    public void ShowPausePanel()
	{
        print("Pause Panel");
        gameUIPanel.SetActive(false);
        pausePanel.SetActive (true);
        GM_.GameIsOn = false;
        //optionsTint.SetActive(true);
        SetSelection(pausePanel);
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
        GM_.GameIsOn = true;
        gameUIPanel.SetActive(true);
        //optionsTint.SetActive(false);

    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HideGameOverPanel() {
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    //Call this function to deactivate and hide the Pause panel during game play
    public void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
        gameUIPanel.SetActive(false);
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HideCreditsPanel() {
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);

    }
    //Call this function to deactivate and hide the Pause panel during game play
    public void ShowCreditsPanel() {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(false);

    }

    public void HideSatellites() {
        satellites.SetActive(false);

    }
    public void ShowSatellites() {
        satellites.SetActive(true);
    }

    public void HideLogoGGJ() {
        logoGlobalGameJam.SetActive(false);

    }
    public void ShowLogoGGJ() {
        logoGlobalGameJam.SetActive(true);
    }
    
}
