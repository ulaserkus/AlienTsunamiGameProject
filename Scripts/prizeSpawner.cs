using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeSpawner : MonoBehaviour
{
    int randomValue;
   public GameObject[] Prize;
    bool spawned;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        deleteSpawnedObject();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            randomValue = Random.Range(0, Prize.Length);

            Instantiate(Prize[randomValue], gameObject.transform.position, gameObject.transform.rotation);

            spawned = true;
        }
    }


    void deleteSpawnedObject()
    {
        if(spawned == true)
        {
            Destroy(Prize[randomValue], 3f);
            spawned = false;
        }




    }
        
}
