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
                CheckMatch(m_Grid[(int)piece.gridID.x, (int)piece.gridID.y]);
                return;
            }
        }
        Debug.LogError($"ERROR: Could not find a match using {_oldPiece}!");
    }

    /// <summary>
    /// Check if there are potantial matches
    /// </summary>
    /// <param name="_piece"></param>
    private void CheckMatch(GridObject _piece)
    {
        //TODO: if you hit the border of the field with spikes, "delete" the spikes.

        //your pieces information
        Pieces yrp = _piece.gridObject.GetComponent<Pieces>();

        //check the x axis for gridObject on the 2D array
        for (int x = -1; x <= 1; x += 2)
        {
            int calX = (int)_piece.gridID.x + x;

            //check if you are inside the bounds of the 2D array
            if (calX >= 0 && calX < m_GridSize.x)
            {
                Pieces opp = m_Grid[calX, (int)_piece.gridID.y].gridObject.GetComponent<Pieces>();
                if (opp != null)
                {
                    //check if the opponent is to your left
                    if (x == -1) 
                    {
                        if (yrp.m_Spikes.spikesLeft > opp.m_Spikes.spikesRight)
                        {
                            //update opponents color
                            opp.m_Color = yrp.m_Color;
                            opp.UpdateColor();
                        }

                        //update your spikes
                        yrp.m_Spikes.spikesLeft = 0;
                        yrp.UpdateSpikes();

                        //update opponents spikes
                        opp.m_Spikes.spikesRight = 0;
                        opp.UpdateSpikes();
                    }
                    //check if the opponent is to your right
                    else if (x == 1) 
                    {
                        if (yrp.m_Spikes.spikesRight > opp.m_Spikes.spikesLeft)
                        {
                            //update opponents color
                            opp.m_Color = yrp.m_Color;
                            opp.UpdateColor();
                        }

                        //update your spikes
                        yrp.m_Spikes.spikesRight = 0;
                        yrp.UpdateSpikes();

                        //update opponents spikes
                        opp.m_Spikes.spikesLeft = 0;
                        opp.UpdateSpikes();
                    }
                }
            }
            //check if border is to your left
            else if (x == -1) 
            {
                //update your spikes
                yrp.m_Spikes.spikesLeft = 0;
                yrp.UpdateSpikes();
            }
            //check if border is to your right
            else if (x == 1) 
            {
                //update your spikes
                yrp.m_Spikes.spikesRight = 0;
                yrp.UpdateSpikes();
            }
        }

        //check the y axis for gridObject on the 2D array
        for (int y = -1; y <= 1; y += 2)
        {
            int calY = (int)_piece.gridID.y + y;

            //check if you are inside the bounds of the 2D array
            if (calY >= 0 && calY < m_GridSize.y)
            {
                Pieces opp = m_Grid[(int)_piece.gridID.x, calY].gridObject.GetComponent<Pieces>();
                if (opp != null)
                {
                    //check if the opponent is below you
                    if (y == -1)
                    {
                        if (yrp.m_Spikes.spikesDown > opp.m_Spikes.spikesUp)
                        {
                            //update opponents color
                            opp.m_Color = yrp.m_Color;
                            opp.UpdateColor();
                        }

                        //update your spikes
                        yrp.m_Spikes.spikesDown = 0;
                        yrp.UpdateSpikes();

                        //update opponents spikes
                        opp.m_Spikes.spikesUp = 0;
                        opp.UpdateSpikes();
                    }
                    //check if the opponent is above you
                    else if (y == 1)
                    {
                        if (yrp.m_Spikes.spikesUp > opp.m_Spikes.spikesDown)
                        {
                            //update opponents color
                            opp.m_Color = yrp.m_Color;
                            opp.UpdateColor();
                        }

                        //update your spikes
                        yrp.m_Spikes.spikesUp = 0;
                        yrp.UpdateSpikes();

                        //update opponents spikes
                        opp.m_Spikes.spikesDown = 0;
                        opp.UpdateSpikes();
                    }
                }
            }
            //check if border is below you
            else if (y == -1)
            {
                //update your spikes
                yrp.m_Spikes.spikesDown = 0;
                yrp.UpdateSpikes();
            }
            //check if border is above you
            else if (y == 1)
            {
                //update your spikes
                yrp.m_Spikes.spikesUp = 0;
                yrp.UpdateSpikes();
            }
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
