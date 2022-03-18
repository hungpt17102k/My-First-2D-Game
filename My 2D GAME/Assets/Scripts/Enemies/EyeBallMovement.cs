using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallMovement : MonoBehaviour
{
    public float stoppingDistance;
    public float retreatDistance;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;       
    }

    public void EyeBallMove(float speed)
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if(distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } 
        else if (distance < stoppingDistance && distance > retreatDistance)
        {
            transform.position = this.transform.position;
        } 
        else if (distance < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
    
}
