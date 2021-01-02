using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPrize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Heal()
    {
        Rewind.health += 5;
        Rewind.greenhealthbar.fillAmount = Rewind.health / 100f;
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
