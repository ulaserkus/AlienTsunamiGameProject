using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Rewind : MonoBehaviour
{
    public GameObject Startbutton;
    public GameObject Shootbutton;
    public GameObject greenHealth;
    public GameObject redhealth;
    public GameObject MainCamera;
    public GameObject rewindButton;
    public static Image greenhealthbar;
    public Transform startPosition;
    public Transform shootPosition;
    public float damage;
    Animation anim;
    public static float health;
    public bool heal = false;
    
   public GameObject pistol;
   public GameObject uzi;
   public GameObject shotgun;
    public GameObject m4a1;
    public GameObject shotgunv2;
    public GameObject pistolv2;
    public GameObject rifle;
    public GameObject ak47;
    public GameObject deagle;
   
  
    
    public AudioSource background;
    public AudioSource doorSound;
    public GameObject CrossHair;


    public GameObject bloodEffect;
    public GameObject grayEffect;

    public GameObject DeahtScreen;
    public Image DeathScreenCounter;
    public float time;
    public CanvasGroup whenIdead;
    public GameObject SPawner;
    public GameObject manaBar;
    public Image BlueBar;
    int mana;
    public Text scoreText;
    public Text goldText;
    public Button continuebutton;
    public Button x2button;

    public bool doOnce;
    public Text GameScore;
    public Text GameGold;
    
    void Start()
    {
        doOnce = true;
        Startbutton.SetActive(true);
        manaBar.SetActive(false);
        DeahtScreen.SetActive(false);
        SPawner.SetActive(false);
        time = 360;
        

        bloodEffect.SetActive(false);
        CrossHair.SetActive(false);
        health = 100;
        
      


        Shootbutton.SetActive(false);
        greenHealth.SetActive(false);
        redhealth.SetActive(false);
        rewindButton.SetActive(false);
        MainCamera.transform.position = startPosition.transform.position;
        MainCamera.transform.rotation = startPosition.transform.rotation;
        greenhealthbar = greenHealth.GetComponent<Image>();
        health = 100;
        Time.timeScale = 1;
        anim = GameObject.FindGameObjectWithTag("ship").GetComponent<Animation>();
        anim.Play("spacecraft_door2_open");
        
        doorSound.Play();
    }
    private void Awake()
    {
        background.Play();
    }

    void Update()
    {
        GameGold.text = GoldCounter.gameGold.ToString();

        GameScore.text = Npc.score.ToString();
        if(health >= 100)
        {
            health = 100;
            doOnce = true;
        }

        Rewınd();

        continuebutton.interactable = true;
        x2button.interactable = true;
    }

    public void Playbutton()
    {


        SPawner.SetActive(true);
        manaBar.SetActive(true);
        CrossHair.SetActive(true) ;
        doorSound.Play();
        background.Stop();
        
      
        Startbutton.SetActive(false);
       
        Shootbutton.SetActive(true);
        greenHealth.SetActive(true);
        redhealth.SetActive(true);
        rewindButton.SetActive(true);
        anim.Play("spacecraft_door2_open");
        MainCamera.transform.position = shootPosition.transform.position;
        MainCamera.transform.rotation = shootPosition.transform.rotation;
        Time.timeScale = 1;

        if (Menu.w1==true){
            pistol.SetActive(true);

           
        }
        else if (Menu.w2 == true)
        {

            shotgun.SetActive(true);
        }
        else if (Menu.w3)
        {
            uzi.SetActive(true);
        }else if (Menu.w4)
        {

            m4a1.SetActive(true);

        }
        else if (Menu.w5)
        {

            shotgunv2.SetActive(true);
        }
        else if (Menu.w6)
        {

            pistolv2.SetActive(true);

        }
        else if (Menu.w7)
        {
            rifle.SetActive(true);

        }
        else if (Menu.w8)
        {

            ak47.SetActive(true);
        }
        else if (Menu.w9)
        {

            deagle.SetActive(true);
        }


    }
    
    public void Rewınd()
    {
        if (health <= 0 )
        {
            shield.manaCount=100;
            time -= 1f;
            DeathScreenCounter.fillAmount = time / 360;
            if(time == 0)
            {
                StartCoroutine(Delay());
                SceneManager.LoadSceneAsync(0);

            }
            CrossHair.SetActive(false);
            
           
          
           
            

            if (doOnce)
            {
                Handheld.Vibrate();
                background.Play();
                doorSound.Play();
              //  anim.Play("spacecraft_door2_close");
                doOnce = false;
            }
            
        
            pistol.SetActive(false);
            uzi.SetActive(false);
            shotgun.SetActive(false);
            Startbutton.SetActive(false);
            Shootbutton.SetActive(false);
            greenHealth.SetActive(false);
            redhealth.SetActive(false);
            rewindButton.SetActive(false);
            whenIdead.alpha = 0;
            whenIdead.blocksRaycasts = false;
            whenIdead.interactable = false;

            

            DeahtScreen.SetActive(true);
            scoreText.text = Npc.score.ToString();
            goldText.text = GoldCounter.totalMoney.ToString();

            MainCamera.transform.position = startPosition.transform.position;
            MainCamera.transform.rotation = startPosition.transform.rotation;


            

            

        }
       
        if(health <= 25)
        {
            grayEffect.SetActive(false);

        }
        else
        {
            grayEffect.SetActive(true);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "laser")
        {
            
            health -= damage;
            greenhealthbar.fillAmount = health / 100f;
            bloodEffect.SetActive(true);
            StartCoroutine(waitBloodEffect());



        }
    }
   
    IEnumerator Wait(float time)
    {

       
        yield return new WaitForSeconds(time);
        

        // Code to execute after the delay
    }
    IEnumerator Delay(float time)
    {

        heal = true;
        yield return new WaitForSeconds(time);

        heal =false;
        // Code to execute after the delay
    }

    IEnumerator waitBloodEffect()
    {

        yield return new WaitForSeconds(0.3f);

        bloodEffect.SetActive(false);
    }
    
    public void Continue()
    {
      
        time = 360;
        health = 100;
        greenhealthbar.fillAmount = health / 100f;

        mana = 100;
      
        BlueBar.fillAmount = mana / 100f;
        


        Playbutton();
        DeahtScreen.SetActive(false);
        whenIdead.alpha = 1;
        whenIdead.blocksRaycasts = true;
        whenIdead.interactable = true;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }


}

