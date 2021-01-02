using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.Blend("Drone_pervane");
        anim.Blend("Drone_ışık");
         anim.Blend("drone");
     
    }
    
}
