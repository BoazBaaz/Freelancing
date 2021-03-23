using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}
