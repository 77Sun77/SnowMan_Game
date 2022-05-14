using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigid;
    public float moveSpeed;
    public float jumpPower;
    int jumpCount;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    void Update()
    {
        move();
        jump();

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void move()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 dir = new Vector2(h, 0) * moveSpeed;
        myRigid.velocity = new Vector2(dir.x, myRigid.velocity.y);
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            myRigid.velocity = new Vector2(myRigid.velocity.x, 0);
            myRigid.AddForce(Vector2.up * jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.name == "Ground")
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.name == "Head")
        {
            Destroy(enemy.gameObject.transform.parent.gameObject);
        }
    }
}
