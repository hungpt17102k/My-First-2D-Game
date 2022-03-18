using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onBaseTriggerEnter;

    public void BaseTriggerEnter(int id)
    {
        /*if(onBaseTriggerEnter != null)
        {
            onBaseTriggerEnter();
        }*/

        onBaseTriggerEnter?.Invoke(id);
    }

}
