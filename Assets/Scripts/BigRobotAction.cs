using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRobotAction : MonoBehaviour
{
    private float cooldown = 2;
    private float cooldownTimer;
    public GameObject enemyBullet;
    public float enemyBulletSpeed = -3.0f;
    public GameObject eyes;
    public int hp = 3;
    public GameObject disableObject; 


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
            disableObject.SetActive(false); 
            Destroy(this.gameObject);
        }
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
