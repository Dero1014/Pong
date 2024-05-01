using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;

    private int playerScore;
    private int computerScore;

    public static Scoring instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerScored()
    {
        playerScoreText.text = (++playerScore).ToString();
    }

    public void ComputerScored()
    {
        computerScoreText.text = (++computerScore).ToString();
    }

}
