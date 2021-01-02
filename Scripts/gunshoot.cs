using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gunshoot : MonoBehaviour
{
   
    public GameObject laserPrefab;
    // public Camera Main;
    public int ammo  ;
    
     GameObject EnemyGunFront;
    public bool shot = false;
    GameObject[] enemies;
    GameObject Player;
    GameObject boss;
   
   
     AudioSource laserSound;
    
    
    Animation pistolanim;
    private void Start()
    {
        
        ammo = 1;

        Player = GameObject.FindObjectOfType<PlayerShoot>().Player;


       

        laserSound = GameObject.FindGameObjectWithTag("LaserSound").GetComponent<AudioSource>();
       
        

       

      
    }

    void Update()
    {
        boss = GameObject.Find("boss");
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        EnemyGunFront = gameObject;
        if (Input.GetMouseButtonDown(0))
        {
          


        }
        foreach (GameObject enemy in enemies)
        {
           
                
           
                Vector3 relativePos = Player.transform.position - enemy.transform.position;

                // the second argument, upwards, defaults to Vector3.up
                Quaternion rotation = Quaternion.LookRotation(relativePos, new Vector3(0, 1, 0));
            
                enemy.transform.rotation = rotation * Quaternion.Euler(5, 30, 0);
            
                
                 //enemy.transform.LookAt(Player.transform.position);
             /*   if (!shot && enemy!= null)
                {


                    GameObject bulletObject = Instantiate(laserPrefab);
                    bulletObject.transform.position = EnemyGunFront.transform.position + EnemyGunFront.transform.forward;
                    bulletObject.transform.forward = EnemyGunFront.transform.forward;
                    shot = true;
                    laserSound.Play();


                    StartCoroutine(EnemyShoot(1f));
                }*/
                
                /* GameObject bulletObject = Instantiate(bulletPrefab);

                 bulletObject.transform.position = EnemyGunFront.transform.position + EnemyGunFront.transform.forward;
                 bulletObject.transform.forward = EnemyGunFront.transform.forward;*/
         
        }
        

     }
   
    IEnumerator EnemyShoot(float time)
    {
        if (!shot)
        {

        }

        yield return new WaitForSeconds(time);
        shot = false;

        // Code to execute after the delay
    }



}