using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public int shield ;
    
    // Start is called before the first frame update
    void Start()
    {
        shield = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet")){
            Destroy(other.gameObject);
        }
      
    }
    public void HitShield()
    {
       
            shield -= 25;

         



        
        if (shield <= 0)
        {
            Destroy(gameObject);
        }
    }
}
