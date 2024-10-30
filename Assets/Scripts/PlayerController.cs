using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using JetBrains.Annotations;
//using System.Runtime.Remoting.Messaging;
using System;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public float jumpForce = 3.0f;
    public Vector3 jump;
    public bool isGrounded;        
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject gameOverText;
    private int count = 0;
    public int maxlife = 3; 
    public int life; 
    private bool gameOver = false;
    private bool gameWin = false;
    public GameObject playerObject;
    public int GateRestriction; 
    public GameObject GateNumber;
    public int numberjumpsmax;
    int numbersJump;
    public GameObject DoubleJumpMessage;
    private bool djpu = false;
    private float timeToAppear = 2f;
    private float timeWhenDisappear;
    public int numberWin;
    public bool bulletCharge = false; 
    public GameObject playerBullet;
    private float playerBulletSpeed = -10f;
    public GameObject eyes;    


    void Start()
    {
        life = maxlife;
        numbersJump = numberjumpsmax;
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        gameOverText.SetActive(false);
        DoubleJumpMessage.SetActive(false);

        jump = new Vector3(0.0f, 3.0f, 0.0f); 
        
        
    }

    private void FixedUpdate()
    {
        if(gameOver == false) { 
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce(movement * speed); 
        }

        
    }

    private void Update()
    {
        if(life > maxlife) 
        {
            life = maxlife;
        }

        Vector3 playerPos = playerObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver && numbersJump > 0)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            numbersJump--;
            if(numbersJump <= 0) { isGrounded = false; numbersJump = numberjumpsmax; }
                        
        }
        SetCountText();

        if((life == 0 || playerPos.y < -20f) && gameWin == false) 
        {
            gameOver = true; 
            gameOverText.SetActive(true); 
        }

        if(count >= GateRestriction) 
        {
            GateNumber.SetActive(false);  
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        { 
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText(); 
        }
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            numbersJump = numberjumpsmax;
        }

        if (other.gameObject.CompareTag("Bullet")) 
        {
            other.gameObject.SetActive(false);

            if(life > 0) 
            {
                life--;
            }
             
        }

        if (other.gameObject.CompareTag("Trampoline")) 
        {
            rb.AddForce(1.125f * jump * jumpForce, ForceMode.Impulse);
            isGrounded = true;
            numbersJump = numberjumpsmax;
        }


        if(other.gameObject.CompareTag("Healing"))
        {
            life++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Final Floor") && gameWin) 
        {
            rb.isKinematic = true; 
        }

        if (other.gameObject.CompareTag("DoubleJump_PU")) 
        {
            other.gameObject.SetActive(false);
            DoubleJumpMessage.SetActive(true);
            djpu = true;            
            timeWhenDisappear = Time.time + timeToAppear;
            numberjumpsmax = 2;
            numbersJump = 0;
        }

        if (other.gameObject.CompareTag("BulletPowerUp")) 
        {
            bulletCharge = true;
            other.gameObject.SetActive(false);
        }

        if (djpu && (Time.time >= timeWhenDisappear))
        {
            DoubleJumpMessage.SetActive(false);
        }

    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y; 
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString() + " Life:" + life.ToString(); 
        if(count >= numberWin && gameOver == false) 
        {
            winTextObject.SetActive(true);
            gameWin = true;
            speed = 0; 
        }
    }

    void ShootBullet()
    {        

        GameObject tempBullet = Instantiate(playerBullet, eyes.transform.position, eyes.transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.useGravity = false;
        tempRigidBodyBullet.AddForce(tempBullet.transform.right * playerBulletSpeed, ForceMode.Impulse);
        Destroy(tempBullet, 3f);

    }

}
