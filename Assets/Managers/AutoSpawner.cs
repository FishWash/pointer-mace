using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    public static AutoSpawner Instance;

    public int wave = 0;

    [SerializeField] GameObject dotPrefab = null;
    [SerializeField] GameObject blockPrefab = null;
    [SerializeField] GameObject triPrefab = null;

    [SerializeField] float spawnDistance = 16.0f;

    [SerializeField] float dotSpawnTimeMult = 1.0f;
    [SerializeField] float blockSpawnTimeMult = 5.0f;
    [SerializeField] float triSpawnTimeMult = 8.0f;

    [SerializeField] float baseWaveTime = 10.0f;
    [SerializeField] float waveTimeWaveMult = 2.0f;

    [SerializeField] float baseBreakTime = 5.0f;
    [SerializeField] float breakTimeWaveMult = 0.1f;
    bool onBreak = true;

    float spawnTime, waveTime, breakTime;
    Timer dotSpawnTimer, blockSpawnTimer, triSpawnTimer, 
        waveTimer, breakTimer;

    void Awake() {
        Instance = this;
    }

    void Start() {
        dotSpawnTimer = new Timer();
        blockSpawnTimer = new Timer();
        triSpawnTimer = new Timer();
        waveTimer = new Timer();
        breakTimer = new Timer();
    }

    void Update() 
    {
        if (Global.gameState != Global.GameState.Running) return;

        if (!onBreak) {
            if (dotSpawnTimer.isDone && dotPrefab) {
                RandomSpawnInSemiCircle(dotPrefab);
                dotSpawnTimer.SetTime(spawnTime*dotSpawnTimeMult);
            }
            if (wave >= 3 && blockSpawnTimer.isDone && blockPrefab) {
                RandomSpawnInSemiCircle(blockPrefab);
                blockSpawnTimer.SetTime(spawnTime*blockSpawnTimeMult);
            } 
            if (wave >= 5 && triSpawnTimer.isDone && triPrefab) {
                RandomSpawnInSemiCircle(triPrefab);
                triSpawnTimer.SetTime(spawnTime*triSpawnTimeMult);
            } 
            if (waveTimer.isDone) {
                onBreak = true;
                breakTimer.SetTime(breakTime);
                Debug.Log("- BREAK -");
            }
        }
        else {
            if (breakTimer.isDone) {
                onBreak = false;
                wave++;
                waveTimer.SetTime(waveTime);
                // Update time values according to wave.
                // spawnTime has a fixed formula because 
                // it can be adjusted with multipliers
                spawnTime = 1/Mathf.Pow(1.1f, wave);
                waveTime = baseWaveTime + waveTimeWaveMult*wave;
                breakTime = baseBreakTime + breakTimeWaveMult*wave;

                Debug.Log("===== WAVE " + wave + " =====");
                Debug.Log("spawnTime: " + spawnTime);
                Debug.Log("waveTime: " + waveTime);
                Debug.Log("breakTime: " + breakTime);
            }
        }
    }

    void RandomSpawnInSemiCircle(GameObject prefab) 
    {
        float angle = Random.Range(0, 180);
        float inverseAngle = (angle + 180) % 360;
        Quaternion rotation = 
            Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion inverseRotation = 
            Quaternion.AngleAxis(inverseAngle, Vector3.forward);
        Vector3 spawnPosition = rotation * new Vector3(spawnDistance, 0, 0);

        Instantiate(prefab, spawnPosition, inverseRotation);
    }
}
