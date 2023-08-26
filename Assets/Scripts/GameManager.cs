using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
    }

    public enum GameResult
    {
        None,
        Won,
        Lost
    }

    public GameState CurrentGameState { get; private set; }
    public GameResult CurrentGameResult { get; private set; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CurrentGameState = GameState.Start;
        UIManager.instance.ShowStartScreen();
    }

    public void StartGame()
    {
        CurrentGameState = GameState.Playing;
        UIManager.instance.HideStartScreen();
    }

    public void PauseGame()
    {
        if (CurrentGameState == GameState.Playing)
        {
            CurrentGameState = GameState.Paused;
            UIManager.instance.ShowPauseScreen();
        }
    }

    public void ResumeGame()
    {
        if (CurrentGameState == GameState.Paused)
        {
            CurrentGameState = GameState.Playing;
            UIManager.instance.HidePauseScreen();
        }
    }

    public void EndGame(GameResult result)
    {
        CurrentGameState = GameState.GameOver;
        CurrentGameResult = result;
        UIManager.instance.ShowEndScreen();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
