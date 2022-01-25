using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text livesText;

    int score = 0;
    int lives = 3;
    public GameObject threeLives, twoLives, oneLives, zeroLives;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = (score.ToString());
        livesText.text = ("LIVES: " + lives.ToString());
    }

    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }

        if (lives == 2)
        {
            threeLives.SetActive(false);
            twoLives.SetActive(true);
        }

        if (lives == 1)
        {
            twoLives.SetActive(false);
            oneLives.SetActive(true);
        }

        if (lives == 0)
        {
            oneLives.SetActive(false);
            zeroLives.SetActive(true);
        }

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");

    }

    public void AddScore ()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void TakeAwayLife()
    {
        lives -= 1;
        livesText.text = ("LIVES: " + lives.ToString());
    }
}
