using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spa : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPoints; // An Vector3 array can also be used
    public List<GameObject> spawnedObjects; // Containing all spawned Objects; Using List to simply call .Add(GameObject);
    public int spawnCount; // How many objects should be spawned
    private int objectIndex; // Random objectsToSpawn index
    private int spawnIndex; // Random spawnPoints index
    public int number;
    private void Start()
    {
        // Use this for loop to not hardcode the spawn count
       /* for (int i = 0; i < spawnCount; i++)
        {
            // For each iteration generate a random index; You could make an int array containing if an object already got spawned and change the index.
            objectIndex = Random.Range(0, objectsToSpawn.Length);
            spawnIndex = Random.Range(0, spawnPoints.Length);
            // Instantiate object
            GameObject go = Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            // Add Object to spawnedObjects List
            spawnedObjects.Add(go);
            
        }*/
    }
    private void Update()
    {
        
        number = spawnedObjects.Count;
        if(number < spawnCount)
        {
            objectIndex = Random.Range(0, objectsToSpawn.Length);
            spawnIndex = Random.Range(0, spawnPoints.Length);
            // Instantiate object
            GameObject go = Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            // Add Object to spawnedObjects List
            spawnedObjects.Add(go);
            if (GameObject.FindObjectOfType<Npc>().destroyed)
            {
                number--;
            }
        }
    }
    /// <summary>
    /// Draws a Sphere at each spawnPoints position
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Gizmos.DrawSphere(spawnPoints[i].position, 0.5f);
        }
    }
    public void Spawn()
    {
        
        for (int i = 0; i < spawnCount; i++)
        {
            if (i >= spawnCount)
            {
                break;
            }
            // For each iteration generate a random index; You could make an int array containing if an object already got spawned and change the index.
          
            
        }
    }
}