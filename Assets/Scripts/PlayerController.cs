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
    private int count;
    public int life = 2; 
    private bool gameOver = false;
    private bool gameWin = false;
    public GameObject playerObject; 
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        gameOverText.SetActive(false);
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
        Vector3 playerPos = playerObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            isGrounded = false;            
        }
        SetCountText();

        if((life == 0 || playerPos.y < -20f) && gameWin == false) 
        {
            gameOver = true; 
            gameOverText.SetActive(true); 
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
        }

        if (other.gameObject.CompareTag("Bullet")) 
        {
            other.gameObject.SetActive(false);

            if(life > 0) 
            {
                life--;
            }
             
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
        if(count >= 11 && gameOver == false) 
        {
            winTextObject.SetActive(true);
            gameWin = true;
        }
    }

}
