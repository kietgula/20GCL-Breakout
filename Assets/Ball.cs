using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Ball : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;

    [Tooltip("this offset use for randomize direction bounce of the ball")]
    public float offset = 0.5f;
    public float speed = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        gameManager.BallList.Add(this.gameObject);
        rb = GetComponent<Rigidbody2D>();

        //* random velocity to make sure the ball is too easy to predict
        rb.velocity = new Vector2(Random.Range(-0.2f,0.2f), 1*speed);

        player = GameObject.Find("Player");
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
            int thisBallIndex = gameManager.BallList.IndexOf(this.gameObject);
            gameManager.BallList.RemoveAt(thisBallIndex);
            Destroy(this.gameObject);
            gameManager.GameOver();
        }
        else if (collision.gameObject.tag=="Brick")
        {
        }

        if (collision.gameObject.tag == "Ball")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }


}
