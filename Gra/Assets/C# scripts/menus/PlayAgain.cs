using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class responsible for playing the scene again.
/// </summary>
public class PlayAgain : MonoBehaviour {
    /// <summary>
    /// "Game over" canvas.
    /// </summary>
    public Transform canvas;

    /// <summary>
    /// Starts the same level again.
    /// </summary>
    /// <param name="level">Level to play.</param>
    public void StartLevel(int level)
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
}
