using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooser : MonoBehaviour
{
    public GameObject player;
    private String playerName;

    void Start()
    {
        playerName = StartPlayingScene.playerName;
        if (playerName == null)
            playerName = "Button1Player";

        if (playerName == "Button1Player")
        {
			player.GetComponent<AIEnemy> ().enabled = true;
        }
        else if (playerName == "Button2Players")
        {
			player.GetComponent<AIEnemy> ().enabled = false;
        }

    }
}
