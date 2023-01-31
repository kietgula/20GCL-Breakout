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
    public GameObject GameWinText;
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
        
        // //if there is no highscore
        // if (float.IsInfinity(PlayerPrefs.GetFloat("HighScore", Mathf.Infinity)))
        // {
        //     //then the default highscore is infinity
        //     PlayerPrefs.SetFloat("HighScore", Mathf.Infinity);
        // }
    }

    void Update()
    {
        if (BrickSpawner.GetComponent<BrickSpawner>().BrickList.Count <= 0 )
        {
            GameWin(TimeCount.time);
        }
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

    public void GameWin(float time)
    {
        bool isHighScore = false;
        state = GameState.win;
        Time.timeScale = 0;

        float currentHighScore = PlayerPrefs.GetFloat("HighScore",Mathf.Infinity);

        if (currentHighScore>TimeCount.time)
        {
            PlayerPrefs.SetFloat("Highscore",TimeCount.time);
            isHighScore = true;
        }

        Background.SetActive(true);
        GameWinText.SetActive(true);
        PlayAgainButton.transform.position = new Vector3(150,150,0);

        GameWinText.GetComponent<TextMeshProUGUI>().text = "YOU WIN: your time is:" + TimeCount.time + " Shortest time is: " + PlayerPrefs.GetFloat("HighScore");

        if (isHighScore)
        {
            GameWinText.GetComponent<TextMeshProUGUI>().text = "YOU WIN: your time is:" + TimeCount.time + " shortest one. Congratulation!! ";
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
            
            while (GameManager.BallList.Count>0)
            {
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
            state = GameState.playing;
            Background.SetActive(false);
            GameOverText.SetActive(false);
            PlayAgainButton.transform.position= new Vector3(265,502,0);

            while (GameManager.BallList.Count>0)
            {
                var currentBall = GameManager.BallList[0];
                GameManager.BallList.RemoveAt(0);
                Destroy(currentBall);
                Ball.NumOfBall--;
            }

            Time.timeScale = 1;
            BrickSpawner.GetComponent<BrickSpawner>().Restart();
            Player.GetComponent<Player>().Balls = 5;
            BallText.GetComponent<TextMeshProUGUI>().text = "Ball:" + Player.GetComponent<Player>().Balls;
            TimeCount.time = 0;
        }
    }
    
}
