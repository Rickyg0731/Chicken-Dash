using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_script : MonoBehaviour
{
    public GameObject train_1;
    public GameObject train_2;
    public GameObject train_3;
    public GameObject bomb;

    void Start()
    {
        int num = Random.Range(0, 3);
        if(num == 0)
        {
            train_1.SetActive(true);
            train_2.SetActive(false);
            train_3.SetActive(false);
        }
        if (num == 1)
        {
            train_1.SetActive(false);
            train_2.SetActive(true);
            train_3.SetActive(false);
        }
        if (num == 2)
        {
            train_1.SetActive(false);
            train_2.SetActive(false);
            train_3.SetActive(true);
        }
        else
        {
            train_1.SetActive(true);
            train_2.SetActive(false);
            train_3.SetActive(false);
        }

        int bomb_ran = Random.Range(0, 20);
        if(bomb_ran == 10)
        {
            bomb.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<player_script>().die();
        }
    }
}
