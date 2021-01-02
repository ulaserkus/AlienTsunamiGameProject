using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class SpawnEnemy : MonoBehaviour
{
    public enum spawnState { Spawning,Waiting,Counting };

    [System.Serializable]
    public class wave
    {
        public string name;
        public Transform[] enemy;
        
        public int count;
        public float rate;
        

       
    }
   
    public wave[] waves;
    private  int nextWave = 0;
    public Transform[] spawnPoints;
    
  
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
 
    private float searchCountdown = 1f;
    public spawnState state = spawnState.Counting;
 
    public int score;
    public int highest;
    
    GameObject enemy;
   
    private void Start()
    {
        
        waveCountdown = timeBetweenWaves;
       

    }
    private void Update()
    {
        if(Rewind.health <= 0)
        {
            nextWave = 0;
        }
        enemy = GameObject.FindGameObjectWithTag("enemy");
       
     
        if (state == spawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
              
                // begin new round
                WaveCompleted();
               
            }
            else
            {
                return;
            }


            // check if enemies alive
        }
        if (waveCountdown <= 0)
        {
            searchCountdown = 1f;
            if(state != spawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                //start spawning

            }
        }
        else
        {
            waveCountdown -= Time.deltaTime * 15;
        }
      
        
    }
    void WaveCompleted()
    {
       
        
       
        state = spawnState.Counting;
        waveCountdown = timeBetweenWaves;
        if(nextWave + 1 > waves.Length-1)
        {
            nextWave = 0;
            //all waves completed
        }
        else
        {
            nextWave++;
            
        }
      

    }

    bool EnemyIsAlive()
    {

        searchCountdown -= Time.deltaTime * 1;
        if(searchCountdown <= 0f)
        {
           
            
                if (enemy == null)
                {

                    return false;
                }
            
           
         

        }
        
        return true;
    }

    IEnumerator SpawnWave(wave _wave)
    {
        state = spawnState.Spawning;
       
        for(int i= 0; i< _wave.count; i++)
        {
           
            Spawn(_wave.enemy);
         
            yield return new WaitForSeconds(1f / _wave.rate);
           
        }

        state = spawnState.Waiting;

        yield break;
    }
    void Spawn(Transform[] _enemy )
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy[Random.Range(0,_enemy.Length)], _sp.position, _sp.rotation);
        
    }
  
  
}
