using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    //private
    private int playerScore = 0;
    private int enemyScore = 0;

    [Header("TMPs")]
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI enemyScoreText;

    [Header("UIPanels")]
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    [Header("TurnIndicator")]
    [SerializeField] GameObject playerFill;
    [SerializeField] GameObject enemyFill;

    private void Start()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    /// <summary>
    /// Update the scores on the canvas
    /// </summary>
    /// <param name="_pScore">New player score</param>
    /// <param name="_eScore">New enemy score</param>
    public void UpdateScore(int _pScore, int _eScore)
    {
        //update player score
        playerScore = _pScore;
        playerScoreText.text = playerScore.ToString();

        //update enemy score
        enemyScore = _eScore;
        enemyScoreText.text = enemyScore.ToString();

        if (_pScore > _eScore && _pScore + _eScore == 9)
            winScreen.SetActive(true);
        else if (_eScore > _pScore && _pScore + _eScore == 9)
            loseScreen.SetActive(true);
    }

    public void UpdateTurnIndicator()
    {
        if (playerFill.activeSelf)
        {
            playerFill.SetActive(false);
            enemyFill.SetActive(true);
        }
        else if (enemyFill.activeSelf)
        {
            playerFill.SetActive(true);
            enemyFill.SetActive(false);
        }
    }
}
