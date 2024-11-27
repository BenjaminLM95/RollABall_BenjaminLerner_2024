using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakPoint : MonoBehaviour
{
    public int hp = 2;
    public Material damagedMaterial;
    public Material deadMaterial;
    public BossRobotScript bScript;
    public GameObject Boss;
    private bool inmune;
    //private bool firstDamage;
    //private bool secondDamage; 

    private void Start()
    {
        bScript = Boss.GetComponent<BossRobotScript>();
        inmune = false;
    }

    
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayersBullet"))
        {
            if(hp>0)
                hp--;

            if(hp == 1) 
            {
                this.GetComponent<Renderer>().material = damagedMaterial;
                bScript.dealDamage(1); 
                
            }
            if (hp <= 0)
            {
                hp = 0;
                this.GetComponent<Renderer>().material = deadMaterial;  
                if(!inmune)
                bScript.dealDamage(2);

                inmune = true; 
            }
            
        }
    }
}
