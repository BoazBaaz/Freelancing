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

        //create the grid for all objects to move on
        m_Grid = new GridObject[(int)m_GridSize.x, (int)m_GridSize.y];
        CreateGrid(m_GridSize.x, m_GridSize.y);
    }

    [Header("Grid")]
    public Vector2 m_GridSize; //the size of the grid
    public Vector2 m_GridOffset; //the offset the grid will be created at
    public GridObject[,] m_Grid; //a 2D array of the grid

    [Header("Temp")]
    public GameObject dummyPiece;

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
                Vector2 dmpPosition = new Vector2(m_GridOffset.x + x, m_GridOffset.y + y);
                GameObject dmP = Instantiate(dummyPiece, dmpPosition, Quaternion.identity);
                m_Grid[x, y] = new GridObject(dmP , dmpPosition);
            }
        }
    }

    /// <summary>
    /// Sets the object to the corresponding grid location
    /// </summary>
    /// <param name="_gridObject">The object you are trying to place</param>
    /// <param name="xGrid">The x position in the grid</param>
    /// <param name="yGrid">The y position in the grid</param>
    /// <returns></returns>
    public void SetGridPieceOnLocation(GameObject _gridObject, int xGrid, int yGrid)
    {
        //check if the grid locations is not already filled.
        if (m_Grid[xGrid, yGrid].gridObject != dummyPiece)
            Debug.LogError($"ERROR: Trying to place {_gridObject} on already full grid location x:{xGrid}, y:{yGrid}");
        else
        {
            _gridObject.transform.position = m_Grid[xGrid, yGrid].gridPosition;
            m_Grid[xGrid, yGrid].gridObject = _gridObject;
        }
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
        public Vector2 gridPosition;

        /// <summary>
        /// Create a gridobject.
        /// </summary>
        /// <param name="_gridObject">The object on the grid tile</param>
        /// <param name="_gridPosition">The tile the object is on in world space</param>
        public GridObject(GameObject _gridObject, Vector2 _gridPosition)
        {
            gridObject = _gridObject;
            gridPosition = _gridPosition;
        }
    }
}
