using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class Level1Management : MonoBehaviour
{
    public bool obStatus;
    public GameObject winObject;
    private float timeToAppear = 1.5f;
    private float timeWhenDisappear;
    private bool activate = true;
    public string nextLevel; 

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        obStatus = winObject.activeSelf;

        if (obStatus && activate) 
        {
            timeWhenDisappear = Time.time + timeToAppear;
            activate = false; 

        }
        if (Time.time >= timeWhenDisappear)
        {
            SceneManager.LoadScene(nextLevel);
        }        

    }
}
