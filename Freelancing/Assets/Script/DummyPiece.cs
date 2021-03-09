using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPiece : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.transform.parent != null)
            if (gameObject.transform.parent.gameObject == GameManager.instance.m_FieldPiecesParent)
                if (GameManager.instance.m_PlayerSelectedPiece != null)
                {
                    GridManager.instance.SetGridPieceOnLocation(GameManager.instance.m_PlayerSelectedPiece, gameObject);
                    GameManager.instance.m_PlayerSelectedPiece = null;
                }
    }
}
