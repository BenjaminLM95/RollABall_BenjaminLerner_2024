using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberScript : MonoBehaviour
{
    private float cooldown = 2;
    private float cooldownTimer;
    public GameObject enemyBullet;
    public float enemyBulletSpeed = -3.0f;
    public GameObject eyes;
    public int hp = 2;
    public float speed = 0.25f;
    public float maxDist = 25.0f;
    public Transform target;
    private float moveCooldown = 1.5f;
    private float moveTimer; 
    public bool active;
    public GameObject reward; 
    

    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        active = true; 
    }

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
        if (hp <= 0)
        {
            GameObject rewardObj = Instantiate(reward, transform.position, transform.rotation) as GameObject; 
            Destroy(this.gameObject);
        }

        if (target == null)
            return;

        // face the target
        //transform.LookAt(target);

        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);



        //so long as the chaser is less than max distance, move towards it at rate speed.
        if (distance < maxDist)
        { 
            if(transform.position.x > target.transform.position.x && active) 
            {
                if(transform.position.z > target.transform.position.z) 
                {
                    transform.position += new Vector3(-1, 0, -1) * speed * Time.deltaTime; 
                }
                else if(transform.position.z < target.transform.position.z) 
                {
                    transform.position += new Vector3(-1, 0, 1) * speed * Time.deltaTime; 
                }
            }
            else if (transform.position.x < target.transform.position.x && active)
            {
                if (transform.position.z > target.transform.position.z)
                {
                    transform.position += new Vector3(1, 0, -1) * speed * Time.deltaTime;
                }
                else if (transform.position.z < target.transform.position.z)
                {
                    transform.position += new Vector3(1, 0, 1) * speed * Time.deltaTime;
                }
            }

            
        }

        if(distance < 5.0f && active) 
        {
            active = false;
            moveTimer = moveCooldown + Time.time; 
            
        } 

        if(Time.time > moveTimer) 
        {
            active = true; 
        }

        //Debug.Log(distance);
         

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayersBullet"))
        {
            hp--;
            if (hp < 0)
            {
                hp = 0;
            }
            Destroy(other);
        }
    }
}


