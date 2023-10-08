using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

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

    public AudioSource pause_sound;
    public AudioSource loose_sound;
    public AudioSource impact_sound;
    public AudioSource camera_sound;
    public GameObject background_music;

    public float game_speed = 25;

    public float score = 0;
    public int best_score = 0;
    int score_int;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI best_text;

    public string turn_left;
    public string turn_Right;

    float speed_timer = 5;
    bool stop_game = false;



    public void die()
    {
        background_music.SetActive(false);
        player_animator.SetInteger("state", 1);
        game_speed = 0;
        stop_game = true;
        loose_sound.Play();
        impact_sound.Play();
        if(score_int > best_score)
        {
            PlayerPrefs.SetInt("best", score_int);
        }

    }

    private void Start()
    {
        best_score = PlayerPrefs.GetInt("best");
    }


    void Update()
    {
        if(stop_game == false)
        {
            best_text.text = best_score.ToString();
            score = score + Time.deltaTime;
            score_int = (int)score;
            score_text.text = score_int.ToString();

        }

        speed_timer = speed_timer - Time.deltaTime;
        if (speed_timer <= 0 && stop_game == false)
        {
            game_speed = game_speed + 4;
            speed_timer = 5;
        }

        //move left
        if (Input.GetKey("a") && player_rig.position.x > -1.584 && stop_game == false ||
            Input.GetAxis(turn_left) < -0.2f && player_rig.position.x > -1.584 && stop_game == false)
        {
            Vector3 player_pos = player_rig.position;
            player_pos.x = player_pos.x - move_amount * Time.deltaTime;
            player_rig.MovePosition(player_pos);
            player_go.transform.SetPositionAndRotation(ROTATE_LEFT_LOCATION.transform.position,ROTATE_LEFT_LOCATION.transform.rotation);
        }
        //move Right
        else if (Input.GetKey("d") && player_rig.position.x < 1.7 && stop_game == false ||
                 Input.GetAxis(turn_Right) > 0.2f && player_rig.position.x < 1.7 && stop_game == false)
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
            camera_sound.Play();
            if (camera_1.activeInHierarchy == true)
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
            pause_sound.Play();
            if (paused_menu_ui.activeInHierarchy == false)
            {
                background_music.SetActive(false);
                paused_menu_ui.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                background_music.SetActive(true);
                paused_menu_ui.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown("q"))
        {
            Application.Quit();
        }

    }
}
