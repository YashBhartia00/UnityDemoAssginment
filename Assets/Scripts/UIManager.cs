using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startScreen, pauseScreen, endScreen, pauseButtonObject;
    public GameObject gameWonMessage, gameLostMessage;
    public Button startButton, continueButton, restartButton, endQuitButton, pauseQuitButton, startQuitButton;

    private Button pauseButton; //get component from the gameObject

    public Slider healthBarSlider;
    public Image healthBarFill, healthBarBackground;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        pauseButton = pauseButtonObject.GetComponent<Button>();

        // Button click listeners
        // can be assigned in inspector too
        startButton.onClick.AddListener(OnStartButtonClicked);
        startQuitButton.onClick.AddListener(OnQuitButtonClicked); 
        pauseQuitButton.onClick.AddListener(OnQuitButtonClicked);
        endQuitButton.onClick.AddListener(OnQuitButtonClicked);
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        pauseButtonObject.SetActive(false);
    }

    public void HideStartScreen()
    {
        startScreen.SetActive(false);
        pauseButtonObject.SetActive(true);
    }

    public void ShowPauseScreen()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        pauseButtonObject.SetActive(false);
    }

    public void HidePauseScreen()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButtonObject.SetActive(true);
    }

    public void ShowEndScreen()
    {
        endScreen.SetActive(true);
        pauseButtonObject.SetActive(false);

        if (Logger.Debug) Logger.Log("Player " + GameManager.instance.CurrentGameResult.ToString());

        if (GameManager.instance.CurrentGameResult == GameManager.GameResult.Lost)
        {
            gameWonMessage.SetActive(false);
            gameLostMessage.SetActive(true);
        }
        else if (GameManager.instance.CurrentGameResult == GameManager.GameResult.Won)
        {
            gameLostMessage.SetActive(false);
            gameWonMessage.SetActive(true);
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBarSlider.value = currentHealth / maxHealth;
    }

    private void OnStartButtonClicked()
    {
        GameManager.instance.StartGame();
    }

    private void OnQuitButtonClicked()
    {
        GameManager.instance.QuitGame();
    }

    private void OnPauseButtonClicked()
    {
        GameManager.instance.PauseGame();
    }

    private void OnContinueButtonClicked()
    {
        GameManager.instance.ResumeGame();
    }

    private void OnRestartButtonClicked()
    {
        GameManager.instance.RestartGame();
    }

}
