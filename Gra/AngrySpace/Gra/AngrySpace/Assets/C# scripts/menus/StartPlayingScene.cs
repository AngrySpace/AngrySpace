using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class responsible for starting playing the game.
/// </summary>
public class StartPlayingScene : MonoBehaviour
{
    /// <summary>
    /// Name of second player depending on playing mode (one or two players).
    /// </summary>
    public static string playerName;

    /// <summary>
    /// Starts playing the game.
    /// </summary>
    /// <param name="level">Scene to play.</param>
    public void StartLevel(int level)
    {
        playerName = EventSystem.current.currentSelectedGameObject.name;
        Time.timeScale = 1;
        Application.LoadLevel(level);
    }
}