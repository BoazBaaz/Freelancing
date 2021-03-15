using UnityEngine;

public class Pieces : MonoBehaviour
{
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

    public enum ColorTypes : int
    {
        Blue = 0,
        Red
    }

    [Header("PieceInfo")]
    public Spikes m_Spikes;
    public ColorTypes m_Color;
    public SpriteRenderer[] m_SidesSR = new SpriteRenderer[4];
    public Sprite[] m_SpikeSprites = new Sprite[5];

    private void Start()
    {
        RandomiseSpikes();
        UpdateSpikes();
        UpdateColor();
    }

    private void OnMouseDown()
    {
        if (gameObject.transform.parent != null)
            if (GameManager.instance.IsPlayerTurn())
            {
                if (gameObject.transform.parent.gameObject == GameManager.instance.m_PlayerPiecesParant)
                    GameManager.instance.m_SelectedPiece = gameObject;
            }
            else if (!GameManager.instance.IsPlayerTurn())
            {
                if (gameObject.transform.parent.gameObject == GameManager.instance.m_EnemyPiecesParent)
                    GameManager.instance.m_SelectedPiece = gameObject;
            }
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
        //TODO: Better spike generation.

        int maximumZeroSpikes = 2;
        int[] spikesAmount = new int[4];


        for (int i = 0; i < spikesAmount.Length; i++)
        {
            bool gotFaledSpikes = false;

            while (!gotFaledSpikes)
            {
                int spikesPercentage = Random.Range(0, 100);

                if (spikesPercentage >= 0 && spikesPercentage < 40 && maximumZeroSpikes != 0)
                {
                    spikesAmount[i] = 0;
                    maximumZeroSpikes--;
                    gotFaledSpikes = true;
                }
                else if (spikesPercentage >= 40 && spikesPercentage < 65)
                {
                    spikesAmount[i] = 1;
                    gotFaledSpikes = true;
                }
                else if (spikesPercentage >= 65 && spikesPercentage < 85)
                {
                    spikesAmount[i] = 2;
                    gotFaledSpikes = true;
                }
                else if (spikesPercentage >= 85 && spikesPercentage < 95)
                {
                    spikesAmount[i] = 3;
                    gotFaledSpikes = true;
                }
                else if (spikesPercentage >= 95 && spikesPercentage < 100)
                {
                    spikesAmount[i] = 4;
                    gotFaledSpikes = true;
                }
            }
        }

        m_Spikes = new Spikes(spikesAmount[0], spikesAmount[1], spikesAmount[2], spikesAmount[3]);
    }

    /// <summary>
    /// Update the spike sprites
    /// </summary>
    public void UpdateSpikes()
    {
        foreach (var side in m_SidesSR)
        {
            //TODO: make eatch side correspand with the spikes in m_spikes
            switch (side.name.ToLower())
            {
                case "up":
                    side.sprite = m_SpikeSprites[m_Spikes.spikesUp];
                    break;
                case "down":
                    side.sprite = m_SpikeSprites[m_Spikes.spikesDown];
                    break;
                case "left":
                    side.sprite = m_SpikeSprites[m_Spikes.spikesLeft];
                    break;
                case "right":
                    side.sprite = m_SpikeSprites[m_Spikes.spikesRight];
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Update the color
    /// </summary>
    public void UpdateColor()
    {
        if (m_Color == ColorTypes.Blue)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        else
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
