using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The AutoSpawner is a big RNG machine that spawns enemies.
It uses a bunch of variables that are designed to make the game harder as wave number increases.
The next wave doesn't start until all enemies have been cleared.
*/

public class AutoSpawner : MonoBehaviour
{
    public static AutoSpawner Instance;

    public static bool debug = true;

    public int wave = 0;
    public static int lastCompletedWave;

    int enemyCount = 0;

    [SerializeField] GameObject dotPrefab = null;
    [SerializeField] GameObject blockPrefab = null;
    [SerializeField] GameObject triPrefab = null;

    [SerializeField] AudioClip waveStartClip = null;

    [SerializeField] float spawnDistance = 16.0f;

    [SerializeField] float dotSpawnTimeMult = 1.0f;
    [SerializeField] float blockSpawnTimeMult = 5.0f;
    [SerializeField] float triSpawnTimeMult = 8.0f;

    [SerializeField] float baseWaveTime = 10.0f;
    [SerializeField] float waveTimeWaveMult = 2.0f;

    [SerializeField] float breakTime = 3.0f;
    bool onBreak = true;

    float spawnTime, waveTime;
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
        // StartNextWave();

        if (lastCompletedWave > 0) {
            Debug.Log("restarting at wave " + lastCompletedWave);
            wave = lastCompletedWave;
        }
    }

    void Update() 
    {
        if (Global.gameState == Global.GameState.Running) 
        {
            if (onBreak) {
                if (breakTimer.isDone) {
                    StartNextWave();
                    onBreak = false;
                }
            }
            else if (!waveTimer.isDone) {
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
            }
        }
 
    }

    public void StartNextWave() 
    {
        // Start with last wave completed
        if (wave < lastCompletedWave) {
            wave = lastCompletedWave;
        }
        else {
            lastCompletedWave = wave;
            wave++;
        }

        // Set variables for spawner
        spawnTime = 1/Mathf.Pow(1.1f, wave);
        waveTime = baseWaveTime + waveTimeWaveMult*wave;
        waveTimer.SetTime(waveTime);

        if (waveStartClip) {
            SoundManager.Instance.PlayClip(waveStartClip);
        }

        if (debug) {
            Debug.Log("===== WAVE " + wave + " =====");
            Debug.Log("Spawn Time Factor: " + spawnTime);
            Debug.Log("Wave Time: " + waveTime);
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

        enemyCount++;
        
        Instantiate(prefab, spawnPosition, inverseRotation);
    }

    public void EnemyDied() {
        enemyCount--;
        if (enemyCount <= 0 && Global.gameState == Global.GameState.Running) {
            onBreak = true;
            breakTimer.SetTime(breakTime);
        }
    }

    public void Reset() {
        lastCompletedWave = 0;
    }
}
