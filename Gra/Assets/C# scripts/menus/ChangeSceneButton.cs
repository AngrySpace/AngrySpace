using UnityEngine;

/// <summary>
/// Class responsible for changing the scenes.
/// </summary>
public class ChangeSceneButton : MonoBehaviour {

    /// <summary>
    /// Starts showing another scene.
    /// </summary>
    /// <param name="level">Scene to play.</param>
    public void StartLevel(int level)
    {
        Time.timeScale = 1;
        Application.LoadLevel(level);
    }
}
