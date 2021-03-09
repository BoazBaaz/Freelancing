using UnityEngine;

public class Pieces : MonoBehaviour
{
    public enum ColorTypes : int
    {
        Blue = 0,
        red
    }

    [System.Serializable]
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


    private void Start()
    {
        if (m_Color == ColorTypes.Blue)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        else
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;


        //TODO: pieces can spawn without any spikes. still needs fixing.

        //int[] spikes = new int[4];

        //for (int i = 0; i < spikes.Length; i++)
        //{
        //    spikes[i] = Random.Range(0, 100);
        //}

        //m_Spikes = new Spikes(spikes[0], spikes[1], spikes[2], spikes[3]);
    }

    private void OnMouseDown()
    {
        if (gameObject.transform.parent != null)
            if (gameObject.transform.parent.gameObject == GameManager.instance.m_PlayerPiecesParant)
                GameManager.instance.m_PlayerSelectedPiece = gameObject;
    }
}
