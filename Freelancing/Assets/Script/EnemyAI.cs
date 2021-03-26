using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private List<GameObject> m_CardList = new List<GameObject>();
    private int m_CardIndex;
    private GameObject m_SelectedCardObject;

    private GameObject m_lastCard;
    private GameObject m_lastGridPiece;
    private int m_cards;

    private void Start()
    {
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
        if (m_cards < 1)
        {
            m_lastCard = GameManager.instance.m_EnemyPiecesParent.transform.GetChild(0).gameObject;

            m_SelectedCardObject = m_lastCard;
        }
        else
        {
            for (int i = 0; i < m_cards; i++)
            {
                m_CardList.Add(GameManager.instance.m_EnemyPiecesParent.transform.GetChild(i).gameObject);
            }

            m_CardIndex = Random.Range(0, m_CardList.Count);

            m_SelectedCardObject = m_CardList[m_CardIndex];
        }

        if (m_SelectedCardObject != null)
        {
            PlaceCard();
        }
    }

    public void PlaceCard()
    {
        int fieldPieceIndex = Random.Range(0, GridManager.instance.m_Grid.Length);

        GameObject currentFieldPiece = GameManager.instance.m_FieldPiecesParent.transform.GetChild(fieldPieceIndex).gameObject;

        if (currentFieldPiece.CompareTag("FieldPieces"))
        {
            if (currentFieldPiece.gameObject.transform.parent != null && m_SelectedCardObject.gameObject.transform.parent != null)
            {
                if (currentFieldPiece.gameObject.transform.parent.gameObject == GameManager.instance.m_FieldPiecesParent)
                {
                    if (currentFieldPiece != null)
                    {
                        GameManager.instance.m_SelectedPiece = m_SelectedCardObject;

                        GridManager.instance.SetGridPieceOnLocation(GameManager.instance.m_SelectedPiece, currentFieldPiece);
                        currentFieldPiece = null;

                        GameManager.instance.SwitchTurn();

                        m_cards--;
                        m_CardList.Clear();
                    }
                }
            }
        }
        else
        {
            return;
        }
    }
}