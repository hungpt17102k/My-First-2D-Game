using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int indexSlot;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[indexSlot] = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && indexSlot + 1 == 3)
        {
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && indexSlot + 1 == 4)
        {
            UseItem();
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<RespawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UseItem()
    {
        foreach(Transform child in transform)
        {
            if (child.name.Contains("Health"))
            {
                child.GetComponent<HealthPotion>().Use();
                GameObject.Destroy(child.gameObject);
            } 
        }
    }

}
