using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Shot : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;
    public Animator animator;

    private float timeBwtShot;
    public float startTimeBwtShot;

    //Ten bien cua animation
    string shot_trigger = "Bow_Shot";

    // Update is called once per frame
    void Update()
    {
        if(timeBwtShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shot();
                timeBwtShot = startTimeBwtShot;
            }
        } else
        {
            timeBwtShot -= Time.deltaTime;
        }
    }

    private void Shot()
    {
        //play animation
        animator.SetTrigger(shot_trigger);

        //Shot arrow prefab
        Instantiate(arrow, shotPoint.position, transform.rotation);
    }
}
