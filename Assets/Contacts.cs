using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contacts : MonoBehaviour
{
    public GameObject thisBullet; 
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Destroy(thisBullet); 
    }
}
