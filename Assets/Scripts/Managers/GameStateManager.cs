using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    Global.GameState lastGameState;

    public bool isPaused {
        get { return (Global.gameState == Global.GameState.Paused); }
        set { Debug.LogError("Can't do that"); }
    }

    void Awake() {
        Instance = this;
        if (Global.gameState == Global.GameState.Off) {
            Global.gameState = Global.GameState.Start;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press Esc to pause
        bool escPressed = Input.GetKeyDown(KeyCode.Escape);
        if (escPressed) {
            if (Global.gameState == Global.GameState.Running) {
                PauseGame();
            }
            else if (Global.gameState == Global.GameState.Paused) {
                UnPauseGame();
            }
        }

        // Handle mouse click
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray)) 
            {
                switch(Global.gameState) 
                {
                    case Global.GameState.Start:
                        StartGame();
                        break;
                    case Global.GameState.GameOver:
                        GameOver();
                        break;
                }
            }
        }

    }

    public void StartGame()
    {
        Global.gameState = Global.GameState.Running;
    }

    public void PauseGame() 
    {
        Global.gameState = Global.GameState.Paused;
        Time.timeScale = 0;
        MusicManager.Instance.PauseMusic();
    }

    public void UnPauseGame() 
    {
        Global.gameState = Global.GameState.Running;
        Time.timeScale = 1;
        MusicManager.Instance.UnPauseMusic();
    }

    public void GameOver()
    {
        Global.gameState = Global.GameState.GameOver;
        MusicManager.Instance.PauseMusic();
    }

    public void Retry()
    {
        Global.gameState = Global.GameState.Running;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToTitle()
    {
        AutoSpawner.Instance.Reset();
        Time.timeScale = 1;
        Global.gameState = Global.GameState.Start;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
