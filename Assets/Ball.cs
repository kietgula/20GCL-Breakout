using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallFallEvent: UnityEvent<int, int>
{

}

public class Ball : MonoBehaviour
{
    public static int NumOfBall;
    public static BallFallEvent BallFall;

    GameObject gameManager;
    GameObject player;

    [Tooltip("this offset use for randomize direction bounce of the ball")]
    public float offset = 0.5f;
    public float speed = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.BallList.Add(this.gameObject);

        NumOfBall++;

        rb = GetComponent<Rigidbody2D>();

        //* random velocity to make sure the ball is too easy to predict
        rb.velocity = new Vector2(Random.Range(-0.2f,0.2f), 1*speed);

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        if (BallFall == null)
        {
            BallFall = new BallFallEvent();
            BallFall.AddListener(gameManager.GetComponent<GameManager>().GameOver);

        }

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

            NumOfBall--;
            int thisBallIndex = GameManager.BallList.IndexOf(this.gameObject);
            GameManager.BallList.RemoveAt(thisBallIndex);
            int Balls = player.GetComponent<Player>().Balls;
            BallFall.Invoke(NumOfBall, Balls);
            
            Destroy(this.gameObject);
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
