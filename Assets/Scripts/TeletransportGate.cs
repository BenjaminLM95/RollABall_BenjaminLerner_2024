using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportGate : MonoBehaviour
{
    //public GameObject player;
    Vector3 posToTransport = new Vector3(); 
    // Start is called before the first frame update
    private void Start()
    {
        posToTransport = new Vector3(0.86f, 0.5f, 80.64f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        other.gameObject.transform.position = posToTransport; 
    }


}
