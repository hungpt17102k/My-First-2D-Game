using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    //Script nay chi la de test Event
    public int id;

    //public GameObject weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.current.BaseTriggerEnter(id);
        } 
    }

    
}
