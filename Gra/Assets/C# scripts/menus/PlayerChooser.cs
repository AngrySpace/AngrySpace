using System;
using UnityEngine;

/// <summary>
/// Class responsible for settig proper fields after user chooses playing mode (one or two players).
/// </summary>
public class PlayerChooser : MonoBehaviour
{
    /// <summary>
    /// Player (enemy of main player).
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Player name on button which user click to choose playing mode.
    /// </summary>
    private String playerName;

    /// <summary>
    /// Checks playing mode (one or two players). If it is one player, the enemy should have AI Component.
    /// </summary>
    void Start()
    {
        playerName = StartPlayingScene.playerName;
        if (playerName == null)
            playerName = "Button1Player";

        if (playerName == "Button1Player")
        {
			player.GetComponent<AIEnemy> ().enabled = true;
            player.GetComponent<PlayerKeyController>().enabled = false;
        }
        else if (playerName == "Button2Players")
        {
			player.GetComponent<AIEnemy> ().enabled = false;
            player.GetComponent<PlayerKeyController>().enabled = true;
        }
    }
}
