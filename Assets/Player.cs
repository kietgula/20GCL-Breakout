using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    //*this Balls is the number of Ball that player can shoot out
    public int Balls;
    public GameObject BallPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-1,0,0)*speed*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(1,0,0)*speed*Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Balls > 0)
                ShootBall();
        }
    }

    void ShootBall()
    {
        Balls --;
        GameManager.NumOfBall ++;
        var newBall = Instantiate(BallPrefab);
        Vector3 newBallPosition = transform.position + new Vector3 (0,0.1f,0);
        newBall.transform.position = newBallPosition;
        float currentBallSpeed;
        if (GameObject.Find("Ball") != null)
            currentBallSpeed = GameObject.Find("Ball").GetComponent<Ball>().speed;
        else currentBallSpeed = 5;
        newBall.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1)*speed;
    }
}
