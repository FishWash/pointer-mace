using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance;

    public enum GameState {Off, Start, Running, Paused, GameOver}
    public static GameState gameState;

    public static float points = 0;

    public Vector3 enemyGoal = Vector3.zero;

    [SerializeField] GameObject hitsparkPrefab = null;

    void Start() {
        Instance = this;
        points = 0;
    }

    public static void InstantiateHitspark(Vector3 position, Quaternion rotation) 
    {
        Instantiate(Instance.hitsparkPrefab, position, rotation);
    }
}
