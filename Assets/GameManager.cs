using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    enum GameState{
        playing,
        gameover,
        win
    }

    GameState state;

    public GameObject Background;
    public GameObject GameOverText;
    public GameObject PlayAgainButton;
    public GameObject BallText;
    public GameObject BrickSpawner;
    public GameObject Player;

    public static List<GameObject> BallList;

    void Start()
    {
        if (GameManager.BallList==null)
        {
            GameManager.BallList = new List<GameObject>();
        }
        

        state = GameState.playing;

    }

    void Update()
    {
    }

    public void GameOver(int NumOfBall, int Balls)
    {
        if (NumOfBall<=0 && Balls<=0)
        {
            state = GameState.gameover;
            Time.timeScale = 0;

            Background.SetActive(true);
            GameOverText.SetActive(true);
            PlayAgainButton.transform.position = new Vector3(150,150,0);
            
        }
    }

    public void PlayAgain()
    {

        if (state == GameState.gameover)
        {
            state = GameState.playing;
            Background.SetActive(false);
            GameOverText.SetActive(false);
            PlayAgainButton.transform.position= new Vector3(265,502,0);

            Time.timeScale = 1;
            BrickSpawner.GetComponent<BrickSpawner>().Restart();
            Player.GetComponent<Player>().Balls = 5;
            BallText.GetComponent<TextMeshProUGUI>().text = "Ball:" + Player.GetComponent<Player>().Balls;
            TimeCount.time = 0;
        }
        else if (state == GameState.playing)
        {
            state = GameState.playing;



            Debug.Log("Hello");
            while (GameManager.BallList.Count>0)
            {
                Debug.Log(Ball.NumOfBall);
                var currentBall = GameManager.BallList[0];
                GameManager.BallList.RemoveAt(0);
                Destroy(currentBall);
                Ball.NumOfBall--;
            }
            BrickSpawner.GetComponent<BrickSpawner>().Restart();
            Player.GetComponent<Player>().Balls = 5;
            BallText.GetComponent<TextMeshProUGUI>().text = "Ball:" + Player.GetComponent<Player>().Balls;
            TimeCount.time = 0;
        }
        else if (state==GameState.win)
        {
            Debug.Log("Play Again with win");
        }
    }
    
}
