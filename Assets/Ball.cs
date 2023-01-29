using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Tooltip("this offset use for randomize direction bounce of the ball")]
    public float offset = 0.5f;
    public float speed = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //* random velocity to make sure the ball is too easy to predict
        rb.velocity = new Vector2(Random.Range(-0.2f,0.2f), 1*speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)    
    {
        float magnitude = rb.velocity.magnitude;
        Vector2 newDirection = rb.velocity + new Vector2(Random.Range(-offset,offset),Random.Range(-offset, offset));
        newDirection.Normalize();
        rb.velocity = newDirection*magnitude;

        if (collision.gameObject.name == "BottomWall")
        {
            GameManager.NumOfBall--;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag=="Brick")
        {
            GameManager.Score++;
        }

        if (collision.gameObject.name == "Ball")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }


}
