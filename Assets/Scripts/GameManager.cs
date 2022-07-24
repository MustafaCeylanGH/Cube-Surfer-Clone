using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI yourScoreText;    
    [SerializeField] private GameObject startUI;
    public int score;

    private void Start()
    {
        Time.timeScale = 0;        
        score = 0;
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        startUI.SetActive(false);
    }
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
