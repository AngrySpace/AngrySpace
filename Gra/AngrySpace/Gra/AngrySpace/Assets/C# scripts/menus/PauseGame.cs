using UnityEngine;

/// <summary>
/// Class responsible of pausing the game.
/// </summary>
public class PauseGame : MonoBehaviour {

    /// <summary>
    /// Canvas which is shown when pausing the game.
    /// </summary>
    public Transform canvas;

    /// <summary>
    /// The "Pause Menu" canvas must not be shown by default.
    /// </summary>
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// Gam should be paused and unpaused when user clicks "Escape" key.
    /// </summary>
    void Update () {      
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
	}

    /// <summary>
    /// Pause game - show "Pause Menu" canvas and stop all objects' movement.
    /// </summary>
    public void Pause()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unpause game - go back to playing mode.
    /// </summary>
    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

