using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Sockets;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public int score=0;
    public bool isGameOver = false;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private GameObject GameOverMenu; 
    [SerializeField] private TMP_Text GameOverScoreText;
    [SerializeField] private TMP_Text GameOverBestText;

    public void IncreaseScore() {
        score++;
        ScoreText.text = score.ToString();
    }

    public void GameOver() {
        isGameOver = true;
        GameOverMenu.SetActive(true);

        int bestsorce = PlayerPrefs.GetInt("BestText", 0);

        if (bestsorce < score) {
            bestsorce = score;
            PlayerPrefs.SetInt("BestText", bestsorce);
        }

        GameOverScoreText.text = "Score : " + score.ToString();
        GameOverBestText.text = "Best : " + bestsorce.ToString();
    }

    public void Retry() {
        SceneManager.LoadScene("GamePlay");
    }

    public void Home() {
        Application.Quit();
        Debug.Log("Goodbye");
    }
}
