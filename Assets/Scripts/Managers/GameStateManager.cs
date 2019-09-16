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
            Global.gameState = Global.GameState.Title;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press Esc to pause
        bool escPressed = Input.GetKeyDown(KeyCode.Escape);
        if (escPressed) {
            if (Global.gameState == Global.GameState.Running) {
                Global.gameState = Global.GameState.Paused;
            }
            else if (Global.gameState == Global.GameState.Paused) {
                Global.gameState = Global.GameState.Running;
            }
        }

        // Set timescale based on game state
        if (Global.gameState != lastGameState) 
        {
            switch(Global.gameState) 
            {
                case Global.GameState.Running:
                    UnPauseGame();
                    break;
                case Global.GameState.Paused:
                    PauseGame();
                    break;
                case Global.GameState.GameOver:
                    PauseGame();
                    break;
                default:
                    UnPauseGame();
                    break;
            }
            lastGameState = Global.gameState;
        }

        // Handle mouse click
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray)) 
            {
                switch(Global.gameState) 
                {
                    case Global.GameState.Title:
                        Global.gameState = Global.GameState.Running;
                        break;
                    case Global.GameState.GameOver:
                        Global.gameState = Global.GameState.Running;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                    default:
                        break;
                }
            }
        }

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
}
