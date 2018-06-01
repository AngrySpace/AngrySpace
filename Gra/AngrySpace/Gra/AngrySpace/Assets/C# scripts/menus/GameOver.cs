using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible of showing "Game Over" canvas if one player looses.
/// </summary>
public class GameOver : MonoBehaviour {
    /// <summary>
    /// Text of winner's name.
    /// </summary>
    public Text textWhoWon;
    /// <summary>
    /// Canvas with game over info.
    /// </summary>
    public Transform canvas;
    /// <summary>
    /// Main camera.
    /// </summary>
    public Transform mainCamera;

    /// <summary>
    /// At the beginning of the game, "Game Over" canvas should not be shown.
    /// </summary>
    void Start ()
    {
        canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// If this class is activated, it should show "Game Over" canvas.
    /// </summary>
    void Update ()
    {
        gameOver();
	}

    /// <summary>
    /// Sets game over info to show on the canvas.
    /// </summary>
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

    /// <summary>
    /// Deactivates playing scene and shows "Game Over" canvas.
    /// </summary>
    private void deactiveScene()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
