using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    // Nho cho them animation hoi mau

    public GameObject effect;
    private Transform player;
    private PlayerBehavoir playerHP;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavoir>();
    }

    public void Use()
    {
        // Cho them animation hoi mau
        GameObject healing = Instantiate(effect, player.position, Quaternion.identity);
        Destroy(healing, 0.75f);

        // Hoi lai mau
        playerHP.HealHP(3);

        Destroy(gameObject);
    }

}
