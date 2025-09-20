using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    int score = 0;
    int highScore;
    public TMP_Text scoreText;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        updateScore();
    }

    void updateScore()
    {
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highScore);
            PlayerPrefs.Save();
        }
        scoreText.text = "SCORE: " + score + " | HIGHSCORE: " + highScore;
    }

    public void addScore()
    {
        score += 50;
        updateScore();
    }
}
