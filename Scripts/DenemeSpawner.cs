using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DenemeSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemy;
        public int count;
        public float rate;
       // public Transform spawnPoint;

    }
    public static int EnemiesAlive;
    public Wave[] waves;
    public  Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
  //  public Text waveCountdownText;
    private int waveIndex = 0;
    void Update()
    {
        if (EnemiesAlive > 0)
        {

        }
        if (waveIndex == waves.Length)
        {

            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
      //  waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Wave wave = waves[waveIndex];
       /* spawnPoint = wave.spawnPoint;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);*/
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, _sp.position, _sp.rotation);
    }
}