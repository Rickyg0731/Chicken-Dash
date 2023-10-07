using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Map : MonoBehaviour
{

    public Rigidbody this_rig;
    public float speed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        //move the map
        Vector3 new_position = this_rig.position;
        new_position.z = new_position.z - speed * Time.deltaTime;
        this_rig.MovePosition(new_position);
    }
}
