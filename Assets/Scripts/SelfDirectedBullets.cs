using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelfDirectedBullets : MonoBehaviour
{
    private float cooldown = 2;
    private float cooldownTimer;
    public GameObject enemyBullet;
    public float enemyBulletSpeed;
    public GameObject eyes;
    public GameObject player;
    public float distance;
    public Vector3 directionTo = new Vector3();
    public BossRobotScript brs;
    public GameObject theBoss;

    private void Start()
    {
        theBoss = GameObject.Find("BossRobot");
        brs = theBoss.GetComponent<BossRobotScript>();        
        enemyBulletSpeed = -6f; 
    }

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

        if (brs.health > 15)
        {
            enemyBulletSpeed = -6f;
        }
        else if (brs.health > 6)
        {
            enemyBulletSpeed = -10f;
        }
        else if (brs.health > 0)
        {
            enemyBulletSpeed = -12.5f;
        }
        else
            enemyBulletSpeed = -5f; 


    }
}
