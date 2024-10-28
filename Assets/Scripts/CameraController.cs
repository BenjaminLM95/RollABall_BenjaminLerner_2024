using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset;
    //public float horizontalSpeed = 0.5f;

    void Start()
    {
        
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }

    private void Update()
    {
        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //transform.eulerAngles += new Vector3(0, h, 0); 
    }

}

