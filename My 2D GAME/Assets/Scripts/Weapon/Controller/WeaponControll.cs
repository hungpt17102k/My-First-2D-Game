using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour
{
    public GameObject player;

    public GameObject weapon; //lay tinh chat cua hold weapon

    // Start is called before the first frame update
    void Start()
    {
        //rend = weapon.GetComponent<SpriteRenderer>(); //lay thuoc tinh flip cua sprite
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localScale.x == -1)
        {
            transform.localScale = new Vector3(-1, -1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        FaceMouse();
    }

    //ham de lam vu khi xoay theo huong chuot
    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float posX = transform.position.x;
        float posY = transform.position.y;
        Vector2 direction = new Vector2(mousePosition.x - posX, mousePosition.y - posY);

        transform.right = direction;
    }
}
