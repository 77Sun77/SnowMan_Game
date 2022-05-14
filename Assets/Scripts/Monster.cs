using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform player;

    Rigidbody2D myRigid;
    Vector2 dir;
    void Awake()
    {
        if(GameObject.Find("Player") != null) player = GameObject.Find("Player").transform;

        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
    }

    void move()
    {
        if(player != null)
        {
            float x = player.position.x - transform.position.x;
            if(x > 0) dir = new Vector2(1.5f, 0);
            else dir = new Vector2(-1.5f, 0);
            myRigid.velocity = new Vector2(dir.x, myRigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.name == "Player")
        {
            Destroy(enemy.gameObject);
        }
    }
}
