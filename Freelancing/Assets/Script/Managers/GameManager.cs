using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("Player")]
    public GameObject m_SelectedPiece;

    [Header("Parents")]
    public GameObject m_PlayerPiecesParant;
    public GameObject m_EnemyPiecesParent;
    public GameObject m_FieldPiecesParent;

    [Header("Prefabs")]
    public GameObject dummyPiece;

    //private
    private bool playerTurn = false;

    public void SwitchTurn()
    {
        if (playerTurn)
            playerTurn = false;
        else
            playerTurn = true;
    }

    public bool IsPlayerTurn()
    {
        return playerTurn;
    }
}
