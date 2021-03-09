using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("Grid")]
    public Vector2 m_GridSize; //the size of the grid
    public Vector2 m_GridOffset; //the offset the grid will be created at
    public GridObject[,] m_Grid; //a 2D array of the grid

    private void Start()
    {
        //create the grid
        m_Grid = new GridObject[(int)m_GridSize.x, (int)m_GridSize.y];
        CreateGrid(m_GridSize.x, m_GridSize.y);
    }

    /// <summary>
    /// Create a grid using the a 2D array.
    /// </summary>
    /// <param name="_width"></param>
    /// <param name="_length"></param>
    private void CreateGrid(float _width, float _length)
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _length; y++)
            {
                GameObject dmP = Instantiate(GameManager.instance.dummyPiece, Vector2.zero, Quaternion.identity, GameManager.instance.m_FieldPiecesParent.transform);
                m_Grid[x, y] = new GridObject(dmP , new Vector2(m_GridOffset.x + x, m_GridOffset.y + y), new Vector2(x, y));
            }
        }
    }

    /// <summary>
    /// Sets the object to the grid location of the oldObject
    /// </summary>
    /// <param name="_newPiece">The object you are trying to place</param>
    /// <param name="_oldPiece">The object you are replacing</param>
    /// <returns></returns>
    public void SetGridPieceOnLocation(GameObject _newPiece, GameObject _oldPiece)
    {
        foreach (GridObject piece in m_Grid)
        {
            if (piece.gridObject == _oldPiece && piece.gridObject.name.Contains(GameManager.instance.dummyPiece.name))
            {
                m_Grid[(int)piece.gridID.x, (int)piece.gridID.y].SetObject(_newPiece);
                Destroy(_oldPiece);
                return;
            }
        }
        Debug.LogError($"ERROR: Could not find a match using {_oldPiece}!");
    }

    /// <summary>
    /// Returns the gameObject of the GridObject on the corresponding grid location 
    /// </summary>
    /// <param name="xGrid">The x position in the grid</param>
    /// <param name="yGrid">The y position in the grid</param>
    /// <returns></returns>
    public GameObject GetGridPieceOnLocation(int xGrid, int yGrid)
    {
        return m_Grid[xGrid, yGrid].gridObject;
    }

    [Serializable]
    public struct GridObject
    {
        public GameObject gridObject;
        public Vector2 gridPosition { get; private set; }
        public Vector2 gridID { get; private set; }

        /// <summary>
        /// Create a gridobject.
        /// </summary>
        /// <param name="_gridObject">The object on the grid tile</param>
        /// <param name="_gridPosition">The tile the object is on in world space</param>
        /// <param name="_gridID">The location of the GridObject in the 2D array</param>
        public GridObject(GameObject _gridObject, Vector2 _gridPosition, Vector2 _gridID)
        {
            gridObject = _gridObject;
            gridPosition = _gridPosition;
            gridID = _gridID;

            gridObject.transform.position = gridPosition;
        }

        public void SetObject(GameObject _newObject)
        {
            _newObject.transform.parent = gridObject.transform.parent;
            _newObject.transform.position = gridPosition;

            gridObject = _newObject;
        }
    }
}
