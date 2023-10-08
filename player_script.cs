using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    public Rigidbody player_rig;
    public float move_amount = 2;
    public GameObject ROTATE_LEFT_LOCATION;
    public GameObject ROTATE_RIGHT_LOCATION;
    public GameObject ROTATE_CENTER_LOCATION;
    public GameObject player_go;

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
            player_go.transform.SetPositionAndRotation(ROTATE_LEFT_LOCATION.transform.position,ROTATE_LEFT_LOCATION.transform.rotation);
        }

        //move Right
        if (Input.GetKey("d") && player_rig.position.x < 1.7)
        {
            Vector3 player_pos = player_rig.position;
            player_pos.x = player_pos.x + move_amount * Time.deltaTime;
            player_rig.MovePosition(player_pos);
            player_go.transform.SetPositionAndRotation(ROTATE_RIGHT_LOCATION.transform.position,ROTATE_RIGHT_LOCATION.transform.rotation);
        }
        else
        {
            player_go.transform.SetPositionAndRotation(ROTATE_CENTER_LOCATION.transform.position,ROTATE_CENTER_LOCATION.transform.rotation);
        }

    }
}
