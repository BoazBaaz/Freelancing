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

        RandomiseSpikes();
    }

    private void OnMouseDown()
    {
        if (gameObject.transform.parent != null)
            if (gameObject.transform.parent.gameObject == GameManager.instance.m_PlayerPiecesParant)
                GameManager.instance.m_SelectedPiece = gameObject;
    }

    /// <summary>
    /// Randomise the spikes of this piece. Only 2 sides can have 0 spikes.
    /// Spike percentage per side.
    /// 40% - 0 spikes.
    /// 25% - 1 spikes.
    /// 20% - 2 spikes
    /// 10% - 3 spikes.
    /// 5% - 4 spikes.
    /// </summary>
    private void RandomiseSpikes()
    {
        int maximumZeroSpikes = 2;
        int[] spikesAmount = new int[4];

        
        for (int i = 0; i < spikesAmount.Length; i++)
        {
            int spikesPercentage = Random.Range(0, 100);

            if (spikesPercentage >= 0 && spikesPercentage < 40 && maximumZeroSpikes != 0)
            {
                spikesAmount[i] = 0;
                maximumZeroSpikes--;
            }
            else if (spikesPercentage >= 40 && spikesPercentage < 65)
                spikesAmount[i] = 1;
            else if (spikesPercentage >= 65 && spikesPercentage < 85)
                spikesAmount[i] = 2; 
            else if (spikesPercentage >= 85 && spikesPercentage < 95)
                spikesAmount[i] = 3;
            else if (spikesPercentage >= 95 && spikesPercentage < 100)
                spikesAmount[i] = 4;
        }

        m_Spikes = new Spikes(spikesAmount[0], spikesAmount[1], spikesAmount[2], spikesAmount[3]);
    }
}
