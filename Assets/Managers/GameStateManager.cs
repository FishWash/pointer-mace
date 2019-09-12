using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    Global.GameState lastGameState;

    void Awake() {
        Instance = this;
        if (Global.gameState == Global.GameState.Off)
            Global.gameState = Global.GameState.Title;
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
                    Time.timeScale = 1;
                    break;
                case Global.GameState.Paused:
                    Time.timeScale = 0;
                    break;
                case Global.GameState.GameOver:
                    Time.timeScale = 0;
                    break;
                default:
                    Time.timeScale = 1;
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
}
