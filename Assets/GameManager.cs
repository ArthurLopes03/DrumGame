using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerRythmManager player1RythmManager;
    public PlayerRythmManager player2RythmManager;
    public TextMeshProUGUI playerSign;

    public bool player1Round = true;

    public void NextRound(List<Beat> beats)
    {
        player1RythmManager.timer = 0f;
        player2RythmManager.timer = 0f;

        if (player1Round)
        {
            player2RythmManager.beats.Clear();

            player2RythmManager.beats.AddRange(beats);

            player2RythmManager.isPlaying = true;
        }
        else
        {
            player1RythmManager.beats.Clear();

            player1RythmManager.beats.AddRange(beats);

            player1RythmManager.isPlaying = true;
        }

        player1Round = !player1Round;
        ChangeSign();
    }

    public void ChangeSign()
    {
        if (player1Round)
        {
            playerSign.text = "Player One";
        }
        else if (!player1Round)
        {
            playerSign.text = "Player Two";
        }
    }
}