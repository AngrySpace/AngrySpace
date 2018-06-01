using UnityEngine;

/// <summary>
/// Class responsible for quiting the game.
/// </summary>
public class QuitGame : MonoBehaviour {

    /// <summary>
    /// Quits game.
    /// </summary>
    public void quitGame()
    {
        Application.Quit();
    }
}
