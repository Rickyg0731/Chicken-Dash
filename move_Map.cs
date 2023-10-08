using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Map : MonoBehaviour
{

    public Rigidbody this_rig;
    public float speed = 2;
    public player_script script_player;

    void Start()
    {
        
    }

    void Update()
    {
        speed = script_player.game_speed;
        //move the map
        Vector3 new_position = this_rig.position;
        new_position.z = new_position.z - speed * Time.deltaTime;
        this_rig.MovePosition(new_position);
    }
}
