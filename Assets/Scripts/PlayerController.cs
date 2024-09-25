using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using JetBrains.Annotations;

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
    private int count;
    public GameObject door1; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        jump = new Vector3(0.0f, 3.0f, 0.0f); 
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce(movement * speed); 
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            isGrounded = false;            
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
         
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y; 
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString(); 
        if(count >= 12) 
        {
            door1.SetActive(false); 
            //winTextObject.SetActive(true);
            //speed = 0; 
        }
    }

}
