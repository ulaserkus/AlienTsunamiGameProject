using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;
    private float lifeTimer;



    

    // Start is called before the first frame update


    void Start()
    {
        lifeTimer = lifeDuration;
    
    
    }

    // Update is called once per frame
    void Update()
    {

       






        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyShield")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator wait(float time)
    {
        

        yield return new WaitForSeconds(time);
        

        // Code to execute after the delay
    }



}
