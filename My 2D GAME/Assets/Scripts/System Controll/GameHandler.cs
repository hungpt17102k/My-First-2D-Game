using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform playerPos;
    private Animator player;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => playerPos.position);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavoir>().ani;
    }

    private void Update()
    {
        if (player.GetBool("isDie"))
        {
            // Hien thi bang thong bao
        }
    }
}
