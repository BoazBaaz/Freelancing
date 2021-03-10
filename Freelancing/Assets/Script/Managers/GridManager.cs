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
    [Range(0, 1)]
    public float m_GridSpacing; //the spacing betwean tiles.
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
                m_Grid[x, y] = new GridObject(dmP, new Vector2(m_GridOffset.x + x + (x * m_GridSpacing), m_GridOffset.y + y + (y * m_GridSpacing)), new Vector2(x, y));
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

                //check if there is a match on the field
                CheckMatch(piece);
                return;
            }
        }
        Debug.LogError($"ERROR: Could not find a match using {_oldPiece}!");
    }

    private void CheckMatch(GridObject _yourGridObject)
    {
        //list of gridObjects around _yourGridObject
        List<GridObject> objectsInRange = new List<GridObject>();

        //check the x axis for gridObject on the 2D array
        for (int x = -1; x <= 1; x += 2)
        {
            int calX = (int)_yourGridObject.gridID.x + x;
            if (calX >= 0 && calX < m_GridSize.x)
                objectsInRange.Add(m_Grid[calX, (int)_yourGridObject.gridID.y]);
        }

        //check the y axis for gridObject on the 2D array
        for (int y = -1; y <= 1; y += 2)
        {
            int calY = (int)_yourGridObject.gridID.y + y;
            if (calY >= 0 && calY < m_GridSize.y)
                objectsInRange.Add(m_Grid[(int)_yourGridObject.gridID.x, calY]);
        }

        //list of the opponents around _yourGridObject
        List<Pieces> opponentPieces = new List<Pieces>();

        //add opponents Pieces script (in range) to list
        foreach (GridObject obj in objectsInRange)
        {
            Pieces opp = obj.gridObject.GetComponent<Pieces>();
            Pieces yrp = _yourGridObject.gridObject.GetComponent<Pieces>();

            if (opp != null)
                if (opp.m_Color != yrp.m_Color)
                    opponentPieces.Add(opp);
        }
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
