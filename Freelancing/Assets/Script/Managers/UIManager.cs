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

    private void Start()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
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
    }
}
