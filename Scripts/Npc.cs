
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Npc : MonoBehaviour
{
    private float waitTime;
    public float StartWaitTime=0;
    public float speed;
     GameObject[] moveSpots;
    private int randomSpot;
    public bool interactable = false;
    public bool destroyed = false;

   public float enemyHealth;
   public float  MaxHealth = 100;

    public GameObject healthbarUI;
    public Image healhtbar;
    GameObject plasma;
    public static float Weapondamage { get; set; }
 
    public static int score;

    public int GameScore;
    //GameObject plasma;
    Rigidbody Rigidbody;
    Animator anim;


    
    private void Start()
    {
        healthbarUI.SetActive(false);
        enemyHealth = MaxHealth;
        healhtbar.fillAmount = CalculateHealht();
        StartWaitTime = waitTime;
        moveSpots = GameObject.FindGameObjectsWithTag("waypoint");
        GameScore = 0;
        randomSpot = Random.Range(0, moveSpots.Length);
        plasma = GameObject.FindGameObjectWithTag("Plasma");
        if (plasma != null)
        {
            
            plasma.SetActive(false);
        }

        Rigidbody = gameObject.GetComponent<Rigidbody>();

        anim = gameObject.GetComponent<Animator>();
    }

    
    private void Update()
    {
        weapons();
        healhtbar.fillAmount = CalculateHealht();

        if (enemyHealth < MaxHealth)
        {
            healthbarUI.SetActive(true);

        }

        if(enemyHealth <= 0)
        {
            score += 10;
            GameScore += 10;
            PlayerPrefs.SetInt("Score", score);
            if (plasma != null)
            {
                plasma.SetActive(true);
            }

            Destroy(gameObject, 2f);
            destroyed = true;

            anim.enabled = false;
            //plasma.SetActive(true);
            StartCoroutine(wait(0.2f));


        }
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].transform.position, speed * Time.deltaTime);
      
        if(Vector3.Distance(transform.position,moveSpots[randomSpot].transform.position)<0.2f)
        { if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
               // transform.LookAt(moveSpots[randomSpot]);
                waitTime = StartWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;

            }

        }
        //weapons();

        
    }

    public  void TakeDamage()
    {
        enemyHealth -= Weapondamage;
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {


            // plasma.SetActive(true);

            enemyHealth -= Weapondamage;


            if (Rigidbody != null)
            {

                Rigidbody.velocity = new Vector3(0, 0, 10);

            }





        }
    }*/




   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {

           
           // plasma.SetActive(true);

            enemyHealth -= Weapondamage;

           
                if(Rigidbody != null)
                {

                  Rigidbody.velocity = new Vector3(0, 0, 10);

                }
               


            

        }

    }*/
    IEnumerator wait(float time)
    {
       
        yield return new WaitForSeconds(time);
        destroyed = false;

        // Code to execute after the delay
    }

  
    void weapons()
    {


        if (PlayerShoot.Playershoot.uzi.activeSelf)
        {
            Weapondamage = 30;

        }
        if (PlayerShoot.Playershoot.shotgun.activeSelf)
        {
            Weapondamage = 60;

        }
        if (PlayerShoot.Playershoot.pistol.activeSelf)
        {
            Weapondamage = 40;
        }
        if (PlayerShoot.Playershoot.pistol2.activeSelf)
        {
            Weapondamage = 40;
        }
        if (PlayerShoot.Playershoot.shotgun2.activeSelf)
        {
            Weapondamage = 90;

        }
        if (PlayerShoot.Playershoot.deagle.activeSelf)
        {
            Weapondamage = 100;

        }
        if (PlayerShoot.Playershoot.ak47.activeSelf)
        {
            Weapondamage = 70;

        }
        if (PlayerShoot.Playershoot.m4a1.activeSelf)
        {
            Weapondamage = 70;

        }
        if (PlayerShoot.Playershoot.rifle.activeSelf)
        {
            Weapondamage = 20;

        }

    }

    float CalculateHealht()
    {

        return enemyHealth / MaxHealth ;

    }
  
}