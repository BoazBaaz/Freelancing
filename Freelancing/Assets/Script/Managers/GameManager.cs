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
    public bool m_PlayerTurn = false;

    [Header("Parents")]
    public GameObject m_PlayerPiecesParant;
    public GameObject m_EnemyPiecesParent;
    public GameObject m_FieldPiecesParent;

    [Header("Prefabs")]
    public GameObject dummyPiece;

    public bool IsPlayerTurn()
    {
        return m_PlayerTurn;
    }
}
