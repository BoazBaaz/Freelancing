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

        Time.timeScale = 1f;

        //create the grid for all objects to move on
        m_Grid = new Vector2[(int)m_GridSize.x, (int)m_GridSize.y];
        CreateGrid(m_GridSize.x, m_GridSize.y);
    }

    [Header("Grid")]
    public Vector2 m_GridSize; //the size of the grid
    public Vector2 m_GridOffset; //the offset the grid will be created at
    public Vector2[,] m_Grid; //a 2D array of the grid

    [Header("GridLocations")]
    public List<GridObject> m_PieceGridLocation = new List<GridObject>(); //the pieces location on the grid


    /// <summary>
    /// Create a grid using the a 2D array.
    /// </summary>
    /// <param name="_width"></param>
    /// <param name="_length"></param>
    private void CreateGrid(float _width, float _length)
    {
        for (int y = 0; y < _length; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                m_Grid[x, y] = new Vector2(m_GridOffset.x + x, m_GridOffset.y - y);
            }
        }
    }

    /// <summary>
    /// Get the player position of the x and y value in the grid array.
    /// </summary>
    /// <param name="xVariable">The width of the grid</param>
    /// <param name="yVariable">The length of the grid</param>
    /// <returns></returns>
    public Vector2 GetPlayerGridPosition(int xVariable, int yVariable)
    {
        //return and change the new position
        return m_Grid[xVariable, yVariable];
    }

    [Serializable]
    public struct GridObject
    {
        public GameObject gridObject;
        public Vector2 gridLocation;

        public GridObject(GameObject _gridObject, Vector2 _gridLocation)
        {
            gridObject = _gridObject;
            gridLocation = _gridLocation;
        }
    }
}
