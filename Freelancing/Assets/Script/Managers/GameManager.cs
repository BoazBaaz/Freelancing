using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("Player")]
    public GameObject m_SelectedPiece;

    [Header("Parents")]
    public GameObject m_PlayerPiecesParant;
    public GameObject m_EnemyPiecesParent;
    public GameObject m_FieldPiecesParent;

    [Header("Audio")]
    public AudioSource m_AudioSource;
    public AudioClip m_HitAudio;
    public AudioClip m_LoseAudio;
    public AudioClip m_SwooshAudio;
    public AudioClip m_WinAudio;


    [Header("Prefabs")]
    public GameObject dummyPiece;

    //private
    private bool playerTurn = false;

    public void SwitchTurn()
    {
        if (playerTurn)
            playerTurn = false;
        else
            playerTurn = true;
    }

    public bool IsPlayerTurn()
    {
        return playerTurn;
    }

    public void PlayAudio(AudioClip _audio)
    {
        m_AudioSource.clip = _audio;
        m_AudioSource.Play();
    }
}
