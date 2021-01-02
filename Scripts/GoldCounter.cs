using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class GoldCounter : MonoBehaviour
{
   
    //  public GameObject moneyİmage;// money cost göstericek
     public Animation anim;
    public static int totalMoney;
    public static int purchased;
    public static int gameGold ;
  
    void Start()
    {
        
        anim.Play("diamond");
        
        Destroy(gameObject, 5f);
       
        
        
    }
    public void Money()
    {

        gameGold += 250;
        totalMoney = PlayerPrefs.GetInt("totalmoney");
        totalMoney += gameGold;

        PlayerPrefs.SetInt("totalmoney", totalMoney);
        
        

            
     
        

        
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
          


        }
    }
    private void OnCollisionEnter(Collider collision)
    {
       
    }
    IEnumerator Wait(float time)
    {
       
        yield return new WaitForSeconds(time);

       
        // Code to execute after the delay
    }
 
}
