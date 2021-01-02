using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotNormalShooting : MonoBehaviour
{

     Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;

    private bool onRange = false;

    public Rigidbody projectile;

    AudioSource laserSound;

    public float rand = 1.5f;

    void Start()
    {
        laserSound = GameObject.FindGameObjectWithTag("LaserSound").GetComponent<AudioSource>();
        //float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 0,rand);
        player = GameObject.FindObjectOfType<PlayerShoot>().Player.transform;
    }

    void Shoot()
    {
        
        if (onRange && gameObject.GetComponentInParent<Npc>().enemyHealth >0)
        {
            laserSound.Play();
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }


    }

    void Update()
    {
        
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }


}