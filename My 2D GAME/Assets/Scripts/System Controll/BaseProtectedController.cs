using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProtectedController : MonoBehaviour
{
    public int id;

    private int respawnTime = 0; //to make it respawn 1 time

    public GameObject healPotion;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onBaseTriggerEnter += RespawnHealPotion;
    }

    private void RespawnHealPotion(int id)
    {
        Vector2 healPos = new Vector2(transform.position.x, transform.position.y - 1.2f);

        if(id == this.id && respawnTime == 0)
        {
            Instantiate(healPotion, healPos, Quaternion.identity);
            respawnTime++;
        }  
    }

    private void OnDestroy()
    {
        GameEvents.current.onBaseTriggerEnter -= RespawnHealPotion;
    }
}
