using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakPoint : MonoBehaviour
{
    public int hp = 2;
    public Material damagedMaterial;
    public Material deadMaterial; 
    
    
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayersBullet"))
        {
            hp--;
            if(hp == 1) 
            {
                this.GetComponent<Renderer>().material = damagedMaterial; 
            }
            if (hp < 0)
            {
                hp = 0;
                this.GetComponent<Renderer>().material = deadMaterial; 
            }
            
        }
    }
}
