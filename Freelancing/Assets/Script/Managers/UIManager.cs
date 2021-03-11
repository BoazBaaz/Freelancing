using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static GameManager instance;

    private int playerScore = 0;
    private int enemyScore = 0;

    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI enemyScoreText;

    private void Start()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
    }

    public void AddPlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void LosePlayerScore()
    {
        playerScore--;
        playerScoreText.text = playerScore.ToString();
    }

    public void AddEnemyScore()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }

    public void LoseEnemyScore()
    {
        enemyScore--;
        enemyScoreText.text = enemyScore.ToString();
    }
}
