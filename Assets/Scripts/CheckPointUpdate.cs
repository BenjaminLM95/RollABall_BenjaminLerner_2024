using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointUpdate : MonoBehaviour
{
    public GameObject checkPoint;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Contact"); 
            checkPoint.transform.position = transform.position;
            this.gameObject.SetActive(false); 
        }
    }
}
