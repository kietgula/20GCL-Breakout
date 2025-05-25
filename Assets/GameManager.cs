using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public List<GameObject> BallList = new List<GameObject>();

    void Start()
    {
        state = GameState.playing;
        Time.timeScale = 1f;
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

    public void GameOver()
    {
        if (BallList.Count <= 0)
        {
            state = GameState.gameover;
            Time.timeScale = 0;

            Background.SetActive(true);
            GameOverText.SetActive(true);
        }
    }

    public void GameWin(float time)
    {
        bool isHighScore = false;
        state = GameState.win;
        Time.timeScale = 0;

        float currentHighScore = PlayerPrefs.GetFloat("HighScore", Mathf.Infinity);

        if (currentHighScore>TimeCount.time)
        {
            PlayerPrefs.SetFloat("Highscore",TimeCount.time);
            isHighScore = true;
        }

        Background.SetActive(true);
        GameWinText.SetActive(true);

        GameWinText.GetComponent<TextMeshProUGUI>().text = "YOU WIN: your time is:" + TimeCount.time + " Shortest time is: " + PlayerPrefs.GetFloat("HighScore");

        if (isHighScore)
        {
            GameWinText.GetComponent<TextMeshProUGUI>().text = "YOU WIN: your time is:" + TimeCount.time + " shortest one. Congratulation!! ";
        }
    }

    public void PlayAgain()
    {
        BallList.Clear();
        SceneManager.LoadScene(0);
    }
    
}
