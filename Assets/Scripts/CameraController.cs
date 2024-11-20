using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    public float horizontalSpeed = 0.5f;
    float cameraFieldView;
     

    void Start()
    {
        cameraFieldView = Camera.main.fieldOfView; 
        offset = transform.position - player.transform.position;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }

    private void Update()
    {
        if(Time.timeScale > 0) { 
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0, h, 0); }


        if(Input.GetKeyDown(KeyCode.Z) && Time.timeScale > 0)
        {
            if(Camera.main.fieldOfView < 80.0f)
            Camera.main.fieldOfView += 1.0f; 
        }
        if (Input.GetKeyDown(KeyCode.X) && Time.timeScale > 0)
        {
            if (Camera.main.fieldOfView > 40.0f)
                Camera.main.fieldOfView -= 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.C) && Time.timeScale > 0)
        {
            Camera.main.fieldOfView = cameraFieldView;
        }


    }

}

