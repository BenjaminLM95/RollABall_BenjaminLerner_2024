using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Level1Management : MonoBehaviour
{
    public bool obStatus;
    public GameObject winObject; 

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        obStatus = winObject.activeSelf;

        if (obStatus) 
        {
            System.Threading.Thread.Sleep(300);
            SceneManager.LoadScene("Level 2");

        }       
        
    }
}
