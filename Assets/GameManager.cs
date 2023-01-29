using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    //* this NumOfBall is the number of balls that are flying in game until they fall down to bottom and get destroyed
    public static int NumOfBall = 0;
    float next_score_time = 0;

    void Update()
    {
        if (NumOfBall > 1 && next_score_time<Time.time)
        {
            //only give bonus score when there are >2 flying balls
            Score = Score + NumOfBall - 1;
            next_score_time = Time.time + 1;
        }
    }
    
}
