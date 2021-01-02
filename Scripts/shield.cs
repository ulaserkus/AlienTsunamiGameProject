using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shield : MonoBehaviour
{

    [SerializeField] private Button ShieldButton;
    [SerializeField] private GameObject Shield;
    
    [SerializeField] private GameObject ShieldHealth;
    public GameObject deahtscreen;

    int ShielHealth;
   public static int manaCount;
    




    
    public Image ManaImage;
    
    
    [SerializeField]
    private Image shieldHealtImage;

    int bestScore;

    private Collider ShielCollider;

    void Start()
    {

        ShielCollider = Shield.GetComponent<Collider>();
        ShielHealth = 100;
        manaCount = 100;
        
        Shield.SetActive(false);
        ShielCollider.enabled = false;
        ShieldHealth.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        shieldHealtImage.fillAmount = ShielHealth / 100f;
        /* if ( ShieldButton.interactable == false)
         {




                  ShieldHealth.SetActive(false);
                 Shield.SetActive(false);
                 ShielCollider.enabled = false;





                 shieldHealtImage.fillAmount = ShielHealth / 100f;






         }*/

        if (manaCount <= 25)
        {
            ShieldButton.interactable = false;
        }
        else
        {
            ShieldButton.interactable = true;
        }


        if (ShielHealth <= 0 )
        {
            
            ShieldHealth.SetActive(false);
            Shield.SetActive(false);
            ShielCollider.enabled = false;
            
            shieldHealtImage.fillAmount = ShielHealth / 100f;
           

            ShieldButton.interactable = true;

            if(manaCount <= 0)
            {
                ShieldButton.interactable = false;
                
            }
            
        }
        if( ShielHealth > 0)
        {
            ShieldHealth.SetActive(true);
            Shield.SetActive(true);
            ShielCollider.enabled = true;

            ShieldButton.interactable = false;
        }

       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laser"))
        {

            Destroy(other);
           


           
            ShielHealth -= 10;
            

            shieldHealtImage.fillAmount = ShielHealth / 100f;
            

            

        }
    }


    public void OpenShield()
    {
       
        
            ShieldHealth.SetActive(true);
            Shield.SetActive(true);
            ShielCollider.enabled = true;
           
            ShieldButton.interactable = false;
            ShielHealth = 100;
            manaCount -= 25;

            ManaImage.fillAmount = manaCount / 100f;

        
        
       
    }
    
    

}
