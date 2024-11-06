using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerRythmManager player1RythmManager;
    public PlayerRythmManager player2RythmManager;

    public bool player1Round = true;

    public void NextRound(List<Beat> beats)
    {
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
    }
}