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

    public GameObject camera_1;
    public GameObject camera_2;

    public Animator player_animator;
    public GameObject paused_menu_ui;

    public float game_speed = 25;

    float speed_timer = 5;
    bool stop_game = false;

    public void die()
    {
        player_animator.SetInteger("state", 1);
        game_speed = 0;
        stop_game = true;
    }
   
    void Update()
    {
        speed_timer = speed_timer - Time.deltaTime;
        if (speed_timer <= 0 && stop_game == false)
        {
            game_speed = game_speed + 5;
            speed_timer = 5;
        }

        //move left
        if (Input.GetKey("a") && player_rig.position.x > -1.584 && stop_game == false)
        {
            Vector3 player_pos = player_rig.position;
            player_pos.x = player_pos.x - move_amount * Time.deltaTime;
            player_rig.MovePosition(player_pos);
            player_go.transform.SetPositionAndRotation(ROTATE_LEFT_LOCATION.transform.position,ROTATE_LEFT_LOCATION.transform.rotation);
        }
        //move Right
        else if (Input.GetKey("d") && player_rig.position.x < 1.7 && stop_game == false)
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

        if (Input.GetKeyDown("v"))
        {
            if(camera_1.activeInHierarchy == true)
            {
                camera_1.SetActive(false);
                camera_2.SetActive(true);
            }
            else
            {
                camera_1.SetActive(true);
                camera_2.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused_menu_ui.activeInHierarchy == false)
            {
                paused_menu_ui.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused_menu_ui.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

    }
}
