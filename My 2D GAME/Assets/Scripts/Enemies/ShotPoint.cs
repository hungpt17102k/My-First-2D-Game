using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    private Transform target;

    private float timeBwtShots;
    public float startTimeBwtShots;

    public GameObject bullet;

    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        timeBwtShots = startTimeBwtShots;

        ani = GetComponentInParent<EnemyBehavior>().ani;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();

        // Khi player con song hoac quai vat chua chet thi ban
        if (target.gameObject.GetComponent<PlayerBehavoir>().enabled && !ani.GetBool("isDie"))
        {
            EyeBallShot();
        }
    }

    private void FacePlayer()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        Vector2 direction = new Vector2(target.position.x - posX, target.position.y - posY);

        transform.right = direction;
    }

    private void EyeBallShot()
    {
        if (timeBwtShots <= 0)
        {
            // Instantiate bullet
            Instantiate(bullet, transform.position, transform.rotation);

            timeBwtShots = startTimeBwtShots;
        }
        else
        {
            timeBwtShots -= Time.deltaTime;
        }
    }

}
