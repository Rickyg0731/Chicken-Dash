using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{

    float timer = 4;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
        }
    }


    private void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
