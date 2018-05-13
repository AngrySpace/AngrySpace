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
		
		if (!GameObject.Find("Player1"))
        {
            deactiveScene();
            textWhoWon.text = "Player 2 won!";
        }
		else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            deactiveScene();
            textWhoWon.text = "Player 1 won!";
        }
    }

    private void deactiveScene()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        //mainCamera.GetComponent<InstantiateBullet>().enabled = false;
    }
}
