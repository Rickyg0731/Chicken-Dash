using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    public Rigidbody player_rig;
    public float move_amount = 2;

    void Start()
    {
        
    }

   
    void Update()
    {
        //move left
        if (Input.GetKey("a") && player_rig.position.x > -1.584)
        {
            Vector3 player_pos = player_rig.position;
            player_pos.x = player_pos.x - move_amount * Time.deltaTime;
            player_rig.MovePosition(player_pos);
        }

        //move Right
        if (Input.GetKey("d") && player_rig.position.x < 1.7)
        {
            Vector3 player_pos = player_rig.position;
            player_pos.x = player_pos.x + move_amount * Time.deltaTime;
            player_rig.MovePosition(player_pos);
        }

    }
}
