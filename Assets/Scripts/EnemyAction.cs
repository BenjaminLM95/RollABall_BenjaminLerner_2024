using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private float cooldown = 2;
    private float cooldownTimer;
    public GameObject enemyBullet;
    public float enemyBulletSpeed = -3.0f;
    public GameObject eyes; 
    // Start is called before the first frame update

    void ShootAtPlayer()
    {
       
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0)
        {
            return;
        }

        cooldownTimer = cooldown;
        
        GameObject tempBullet = Instantiate(enemyBullet, eyes.transform.position, eyes.transform.rotation) as GameObject;        
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.useGravity = false;        
        tempRigidBodyBullet.AddForce(tempBullet.transform.up * enemyBulletSpeed, ForceMode.Impulse);        
        Destroy(tempBullet, 1.6f); 
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer();


       
    }
}
