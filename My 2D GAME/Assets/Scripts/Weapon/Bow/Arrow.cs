using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damge;

    public LayerMask whatIsSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyArrow", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //Debug.Log("Enemy hitted");
                hitInfo.collider.GetComponent<EnemyBehavior>().TakeDamge(damge);
            }
            DestroyArrow();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyArrow()
    {
        //Destroy effect


        Destroy(gameObject);
    }
}
