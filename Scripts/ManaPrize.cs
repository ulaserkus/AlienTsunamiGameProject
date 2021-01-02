
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaPrize : MonoBehaviour
{
    private Image ManaImage;
    // Start is called before the first frame update
    void Start()
    {
        ManaImage = GameObject.FindGameObjectWithTag("ManaImage").GetComponent<Image>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mana()
    {
        shield.manaCount += 10;
        ManaImage.fillAmount = shield.manaCount / 100f;
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            
        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            shield.manaCount += 10;
            ManaImage.fillAmount = shield.manaCount / 100f;
            Destroy(gameObject);
        }
    }*/
}
