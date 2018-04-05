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
            InstantiateBulletEnemy.isPlayer2Playing = false;
            player.GetComponent<moveEnemy>().enabled = true;
            player.GetComponent<movePlayer2>().enabled = false;
        }
        else if (playerName == "Button2Players")
        {
            InstantiateBulletEnemy.isPlayer2Playing = true;
            player.GetComponent<moveEnemy>().enabled = false;
            player.GetComponent<movePlayer2>().enabled = true;
        }

    }
}
