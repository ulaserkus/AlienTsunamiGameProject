using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headshot : MonoBehaviour
{
    public GameObject parent;
    public GameObject PartToVanish;//head
    public GameObject replacement;// kafa parcaları sahnede 1 tane olması gerekir chest gibi
    private Animator _anim;
    int randomValue;
    int randomPosition;
    public GameObject[] Prize;
    bool spawned;
    public GameObject[] PrizeTransform;
     AudioSource hs;
  
    GameObject HeadParticle;
    void Start()
    {
        PrizeTransform = GameObject.FindGameObjectsWithTag("SpawnPoints");
        _anim = parent.GetComponent<Animator>();
        hs = GameObject.FindGameObjectWithTag("hsSound").GetComponent<AudioSource>();
      
        
    }
    private void Update()
    {
       if (spawned == true)
        {
            Destroy(Prize[randomValue],2f);
            spawned = false;
        }
        HeadParticle = GameObject.FindGameObjectWithTag("HeadParticle");
        Destroy(HeadParticle, 15f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "bullet")
            return;

        hs.Play();
        _anim.enabled = false;
        GameObject.Instantiate(replacement, transform.position, transform.rotation);
        
        Destroy(PartToVanish);
        Destroy(parent, 2f);

        randomValue = Random.Range(0, Prize.Length);
        randomPosition = Random.Range(0, PrizeTransform.Length);

        Instantiate(Prize[randomValue],PrizeTransform[randomPosition].transform);

    }
    IEnumerator  Wait(float time)
    {

        yield return new WaitForSeconds(time);
       
        

        // Code to execute after the delay
    }
}
