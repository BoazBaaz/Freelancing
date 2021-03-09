using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public enum ColorTypes : int
    {
        Blue = 0,
        red
    }

    [Serializable]
    public struct Spikes
    {
        public int spikesUp;
        public int spikesDown;
        public int spikesLeft;
        public int spikesRight;

        public Spikes(int _sUp, int _sDown, int _sLeft, int _sRight)
        {
            spikesUp = _sUp;
            spikesDown = _sDown;
            spikesLeft = _sLeft;
            spikesRight = _sRight;
        }
    }

    public ColorTypes m_Color;
    public Spikes m_Spikes;
}
