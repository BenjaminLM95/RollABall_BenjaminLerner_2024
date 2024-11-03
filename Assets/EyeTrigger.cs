using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrigger : MonoBehaviour
{
    public GameObject eye;
    public int hp = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (hp <= 0)
        {
            eye.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayersBullet"))
        {
            hp--;
            if (hp < 0)
            {
                hp = 0;
            }
            Destroy(other);
        }
    }
}
