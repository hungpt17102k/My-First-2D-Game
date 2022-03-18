using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private string run = "Speed_Run";

    public float moveSpeed = 5f;

    public Animator animator;

    public Rigidbody2D rigi;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animator.GetBool("isDie") == false)
        {
            Moving();
            FacingMouse();
        }
        else
        {
            rigi.Sleep();
        }
    }

    //Ham di chuyen va xoay nguoi theo huong tro chuot
    private void Moving()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //khi an phim A or D
        float moveVertical = Input.GetAxis("Vertical"); //khi an phim W or S

        //transform.position += new Vector3(moveHorizontal, 0, 0) * moveSpeed * Time.deltaTime;
        //transform.position += new Vector3(0, moveVertical, 0) * moveSpeed * Time.deltaTime;

        //dung rigibody de di chuyen
        rigi.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);

        //dieu kien de cho animation Run chay
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animator.SetFloat(run, 0.03f);
        } else
        {
            animator.SetFloat(run, 0);
        }

    }

    private void FacingMouse()
    {
        //quay theo huong cua tro chuot
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        if (mousePos.x - playerPos.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.x - playerPos.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
