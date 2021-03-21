using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private List<GameObject> m_CardList = new List<GameObject>();
    private int m_CardInt;
    private GameObject m_SelectedCardObject;

    private int m_round;
    private int m_cards;

    private void Start()
    {
        m_round = 8;
        m_cards = 4;
    }

    private void Update()
    {
        if (!GameManager.instance.IsPlayerTurn())
        {
            PickACard();
        }
    }

    public void PickACard()
    {
        GameObject currentCard;

        for (int i = 0; i < m_cards; i++)
        {
            currentCard = GameManager.instance.m_EnemyPiecesParent.transform.GetChild(i).gameObject;

            m_CardList.Add(currentCard);
        }

        m_CardInt = Random.Range(0, m_CardList.Count);
        m_SelectedCardObject = m_CardList[m_CardInt];

        PlaceCard();

        m_cards--;
        m_CardList.RemoveAt(m_CardInt);
    }

    public void PlaceCard()
    {
        int fieldPieceInt = Random.Range(0, m_round);
        GameObject currentFieldPiece = GameManager.instance.m_FieldPiecesParent.transform.GetChild(fieldPieceInt).gameObject;

        if (currentFieldPiece.CompareTag("FieldPieces"))
        {
            GameManager.instance.m_SelectedPiece = currentFieldPiece;

            GridManager.instance.SetGridPieceOnLocation(m_SelectedCardObject, GameManager.instance.m_SelectedPiece);
            GameManager.instance.m_SelectedPiece = null;

            m_round--;

            GameManager.instance.SwitchTurn();
        }
        else
        {
            return;
        }
    }
}