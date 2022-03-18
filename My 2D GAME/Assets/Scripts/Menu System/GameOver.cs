using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Animator ani;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        ani = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavoir>().ani;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ani.GetBool("isDie"))
        {
            gameOver.SetActive(true);
        }
    }
}
