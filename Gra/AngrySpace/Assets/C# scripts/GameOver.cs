using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text textWhoWon;
    public Transform canvas;
    public Transform mainCamera;

    void Start ()
    {
        canvas.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        gameOver();
	}

    public void gameOver()
    {
        if (collisionOnPlayer1Detected.lifes == 0)
        {
            deactiveScene();
            textWhoWon.text = "Player 2 won!";
        }
        else if (collisionOnPlayer2Detected.lifes == 0)
        {
            deactiveScene();
            textWhoWon.text = "Player 1 won!";
        }
    }

    private void deactiveScene()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        mainCamera.GetComponent<InstantiateBullet>().enabled = false;
        mainCamera.GetComponent<InstantiateBulletEnemy>().enabled = false;
    }
}
