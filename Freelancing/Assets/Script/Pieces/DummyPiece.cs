using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPiece : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.transform.parent != null)
            if (gameObject.transform.parent.gameObject == GameManager.instance.m_FieldPiecesParent)
                if (GameManager.instance.m_SelectedPiece != null)
                {
                    GridManager.instance.SetGridPieceOnLocation(GameManager.instance.m_SelectedPiece, gameObject);
                    GameManager.instance.m_SelectedPiece = null;

                    GameManager.instance.SwitchTurn();
                }
    }
}
