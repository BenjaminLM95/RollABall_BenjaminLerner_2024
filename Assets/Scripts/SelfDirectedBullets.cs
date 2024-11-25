using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelfDirectedBullets : MonoBehaviour
{
    private float cooldown = 2;
    private float cooldownTimer;
    public GameObject enemyBullet;
    public float enemyBulletSpeed = -3.0f;
    public GameObject eyes;
    public GameObject player;
    public float distance;
    public Vector3 directionTo = new Vector3(); 
    
    void ShootAtPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        directionTo = (transform.position - player.transform.position).normalized; 

        cooldownTimer -= Time.deltaTime;


        if (cooldownTimer > 0)
        {
            return;
        }

        cooldownTimer = cooldown;

        GameObject tempBullet = Instantiate(enemyBullet, eyes.transform.position, eyes.transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.useGravity = false;
        tempRigidBodyBullet.AddForce(directionTo * enemyBulletSpeed, ForceMode.Impulse);        
        Destroy(tempBullet, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer(); 


    }
}
