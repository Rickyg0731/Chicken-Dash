using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_map : MonoBehaviour
{
    public GameObject map_to_spawn;
    public Transform map_respawn_location;
    public player_script script_player;

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            GameObject map_created = Instantiate(map_to_spawn, map_respawn_location.position, map_respawn_location.rotation);
            move_Map map_script = map_created.GetComponent<move_Map>();
            map_script.script_player = this.script_player;
        }  
    }
}
