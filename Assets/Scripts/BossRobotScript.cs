using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class BossRobotScript : MonoBehaviour
{
    public int health;
    public GameObject Legs;
    public GameObject Torso; 
    public bool firstFall = false;
    public bool lastFall = false;
    public PlayableDirector pdTimeline;
    public PlayableDirector pdTimeLine2; 
    public GameObject reward1; 
    public GameObject reward2;
    public GameObject target1;
    public GameObject target2;
    public GameObject faketarget1;
    public GameObject faketarget2;
    public GameObject reward3; 
    // Start is called before the first frame update
    void Start()
    {
        health = 21; 
        reward1.gameObject.SetActive(false);
        reward2.gameObject.SetActive(false);
        faketarget1.gameObject.SetActive(true);
        faketarget2.gameObject.SetActive(true);
        target1.gameObject.SetActive(false);
        target2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 15) 
        {
            Legs.SetActive(false);
            if (!firstFall) { 
            pdTimeline.Play();
                faketarget1.gameObject.SetActive(false);
                faketarget2.gameObject.SetActive(false);
                target1.gameObject.SetActive(true);
                target2.gameObject.SetActive(true);
                firstFall = true;
                GameObject rewardObj1 = Instantiate(reward1, new Vector3(-16.7f, 3.13f, 118.41f), transform.rotation) as GameObject;
                rewardObj1.gameObject.SetActive(true);
                GameObject rewardObj2 = Instantiate(reward2, new Vector3(14.06f, 3.13f, 118.41f), transform.rotation) as GameObject;
                rewardObj2.gameObject.SetActive(true);
            }

            
        }

        if(health <= 6) 
        {
            Torso.SetActive(false);
            if (!lastFall) 
            {
                pdTimeLine2.Play();
                
                lastFall = true;

                    
            }
        }

        if(health <= 0) 
        {
            GameObject rewardObj3 = Instantiate(reward3, new Vector3(-0.023f, 1.5f, 130.08f), transform.rotation) as GameObject;
            rewardObj3.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }


    public void dealDamage(int damage) 
    {
        if(damage < 0) damage = 0;

        health -= damage;

        if (damage < 0)
            damage = 0; 
    }

   

}
