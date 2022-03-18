using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 spawnPos = new Vector2(player.position.x + 1f, player.position.y);
        Instantiate(item, spawnPos, Quaternion.identity);
    }
}
